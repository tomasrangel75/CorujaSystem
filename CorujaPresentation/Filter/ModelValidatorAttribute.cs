
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net;
using System.Net.Http;

namespace CorujaPresentation.Filter
{
    public class ModelValidatorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
            }


            base.OnActionExecuting(actionContext);
        }
    }
}
