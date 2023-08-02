using ControleDeContatos.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;

namespace ControleDeContatos.Filters
{
    //Filters são muito bons para colocar condicões para o usuário
    //Nesse caso ele impede o usuário acessar páginas internas sem estar logado
    public class PaginaRestritaSomenteAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //guarda o estado da sessão
            string sessao = context.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessao)) 
            {
                //Verifica se é nulo ou vazio, se sim, redirecionapara a tela de login para ele iniciar uma sessão.
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { {"controller","Login" }, {"action","Index" } });
            }
            else
            {
                //Monta o obj novamente.
                UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessao);
                if (string.IsNullOrEmpty(sessao))
                {
                    //Se não for vazio, mas não der para montar o obj novamante ele também redireciona.
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
                if (usuario.Perfil != Enums.PerfilEnum.Admin) 
                {
                    //Se for identificdo que o perfil é diferente de Adm, vai redirecionar para uma tela para os usuário que não são adm.
                    //Cria  controller
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrito" }, { "action", "Index" } });
                }
            }
            base.OnActionExecuted(context);
        }
    }
}
