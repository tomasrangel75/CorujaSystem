using System.Web.Mvc;

namespace CorujaPresentation.Areas.CorujaCrianca
{
    public class CorujaCriancaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CorujaCrianca";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CorujaCrianca_default",
                "CorujaCrianca/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}