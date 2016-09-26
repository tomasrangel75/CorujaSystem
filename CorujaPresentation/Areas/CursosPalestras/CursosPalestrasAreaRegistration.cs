using System.Web.Mvc;

namespace CorujaPresentation.Areas.CursosPalestras
{
    public class CursosPalestrasAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CursosPalestras";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CursosPalestras_default",
                "CursosPalestras/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}