using ControleDeContatos.Filters;
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
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contatoid)
        {
            try
            {
                if (ModelState.IsValid)
                {
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
