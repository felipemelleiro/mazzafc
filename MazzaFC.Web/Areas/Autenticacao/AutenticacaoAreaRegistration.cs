using System.Web.Mvc;

namespace MazzaFC.Web.Areas.Autenticacao
{
    public class AutenticacaoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Autenticacao";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Autenticacao_default",
                "Autenticacao/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}