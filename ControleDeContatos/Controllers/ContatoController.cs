using ControleDeContatos.Filters;
using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        private readonly ISessao _isessao;
        public ContatoController(IContatoRepositorio contatoRepositorio, ISessao isessao)
        {
            _contatoRepositorio = contatoRepositorio;
            _isessao = isessao;
        }
        public IActionResult Index()
        {
            UsuarioModel usuario = _isessao.BuscarSessaoDoUsuario();
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos(usuario.Id);

            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            try
            {
                ContatoModel contato = _contatoRepositorio.ListarPorId(id);
                if (contato.UsuarioId != _isessao.BuscarSessaoDoUsuario().Id)
                {
                    TempData["MensagemErro"] = "Você não tem acesso a este contato";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (System.Exception)
            {

                TempData["MensagemErro"] = "Ops!! Usuário não existe!";
                return RedirectToAction("Index");
            }

        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            if (contato == null)
            {
                TempData["MensagemErro"] = "Ops!! Usuário não existe!";
                return RedirectToAction("Index");
            }
            return View(contato);

        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contatoid)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contatoid.UsuarioId = _isessao.BuscarSessaoDoUsuario().Id;
                    _contatoRepositorio.Adicionar(contatoid);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contatoid);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = "Ops!! Não conseguimos cadastrar o seu contato, tente novamente! Destalhes do erro:" + erro.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alterar(ContatoModel contatoid)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contatoid);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";

                    return RedirectToAction("Index");
                }
                return View("Editar", contatoid);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = "Ops!! Não conseguimos alterar o seu contato, tente novamente! Destalhes do erro:" + erro.Message;
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                _contatoRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Contato deletado com sucesso";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = "Ops!! Não conseguimos deletar o seu contato, tente novamente! Destalhes do erro:" + erro.Message;
                return RedirectToAction("Index"); ;
            }

        }
    }
}
