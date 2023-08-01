using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioModel usuarioid)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioid = _usuarioRepositorio.Adicionar(usuarioid);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuarioid);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = "Ops!! Não conseguimos cadastrar o seu usuário, tente novamente! Destalhes do erro:" + erro.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel usuarioSemSenhaModel)
        {
            try
            {
                UsuarioModel usuario = null;

                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Nome = usuarioSemSenhaModel.Nome,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Perfil = usuarioSemSenhaModel.Perfil,
                    };
                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";

                    return RedirectToAction("Index");
                }
                return View("Editar", usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = "Ops!! Não conseguimos alterar o seu contato, tente novamente! Destalhes do erro:" + erro.Message;
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado) TempData["MensagemSucesso"] = "Usuário deletado com sucesso";
                else TempData["MensagemErro"] = "Usuário deletado com sucesso";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = "Ops!! Não conseguimos deletar o seu Usuário, tente novamente! Destalhes do erro:" + erro.Message;
                return RedirectToAction("Index"); ;
            }

        }
    }

}
    
