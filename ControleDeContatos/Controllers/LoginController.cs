using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {

        protected readonly IUsuarioRepositorio _usuarioRepositorio;
        protected readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            //Se a sessão já estiver criada, a página vai ser redirecionada para a home.
            if (_sessao.BuscarSessaoDoUsuario() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public IActionResult RedefinirSenha() 
        {
            return View("RedefinirSenha");

        }

        public IActionResult Sair() 
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = new UsuarioModel()
                    {
                        Login = loginModel.Login,
                        Senha = loginModel.Senha
                    };
                    
                    if (_usuarioRepositorio.BuscarUsuario(usuario) == true)
                    {
                        usuario = _usuarioRepositorio.BuscarUsuarioo(usuario);
                        //Aqui eu crio uma sessão para o meu usuário.
                        _sessao.CriarSessaoDoUsuario(usuario);
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["MensagemErro"] = "Senha e/ou login incorreto(o). Por favor, tente novamente";

                }

                return View(nameof(Index));


            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = "Ops!! Não conseguimos realizar o seu login, tente novamente! Destalhes do erro:" + erro.Message;
                return View(nameof(Index));
            }
        }

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarUsuarioEmailLogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);
                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        _usuarioRepositorio.Atualizar(usuario);
                        TempData["MensagemSucesso"] = $"Enviamos para o seu e-mail cadastrado uma nova senha.";
                        return RedirectToAction("Index", "Login");

                    }
                    TempData["MensagemErro"] = "Login e/ou E-mail incorreto(s). Por favor, tente novamente";

                }
                return View("RedefinirSenha");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = "Ops!! Não conseguimos redefinir a sua senha, tente novamente! Destalhes do erro:" + erro.Message;
                return View(nameof(Index));
            }
        }
        
    }
}
