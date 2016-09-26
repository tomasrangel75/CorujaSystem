using System.Web.Mvc;

namespace CorujaPresentation.Areas.Colaboradores
{
    public class ColaboradoresAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Colaboradores";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Colaboradores_default",
                "Colaboradores/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}