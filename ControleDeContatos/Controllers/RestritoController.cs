using Microsoft.AspNetCore.Mvc;
using ControleDeContatos.Filters;


namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
