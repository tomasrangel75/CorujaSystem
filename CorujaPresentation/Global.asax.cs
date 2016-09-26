using CorujaPresentation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CorujaPresentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("Enter - Application_Error");

            var httpContext = ((MvcApplication)sender).Context;

            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            var currentController = " ";
            var currentAction = " ";

            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null &&
                        !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    currentController = currentRouteData.Values["controller"].ToString();
                }

                if (currentRouteData.Values["action"] != null &&
                        !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }

            var ex = Server.GetLastError();

            if (ex != null)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);

                if (ex.InnerException != null)
                {
                    System.Diagnostics.Trace.WriteLine(ex.InnerException);
                    System.Diagnostics.Trace.WriteLine(ex.InnerException.Message);
                }
            }

            var controller = new ErrorController();
            var routeData = new RouteData();
           // var action = "CustomError";
            var statusCode = 500;

            if (ex is HttpException)
            {
                var httpEx = ex as HttpException;
                statusCode = httpEx.GetHttpCode();

                //switch (httpEx.GetHttpCode())
                //{
                //    case 400:
                //        action = "BadRequest";
                //        break;

                //    case 401:
                //        action = "Unauthorized";
                //        break;

                //    case 403:
                //        action = "Forbidden";
                //        break;

                //    case 404:
                //        action = "PageNotFound";
                //        break;

                //    case 500:
                //        action = "CustomError";
                //        break;

                //    default:
                //        action = "CustomError";
                //        break;
                //}
            }
            else if (ex is AuthenticationException)
            {
               // action = "Forbidden";
                statusCode = 403;
            }

            httpContext.ClearError();
            httpContext.Response.Clear();
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.TrySkipIisCustomErrors = true;

            routeData.Values["controller"] = "Home";
            //routeData.Values["action"] = action;
            routeData.Values["action"] = "SysError";


            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
            var requestContext = new RequestContext(new HttpContextWrapper(httpContext), routeData);
            var controll = factory.CreateController(requestContext, "Error");

            httpContext.Response.ContentType = "text/html";
            
            try
                {
                controll.Execute(requestContext);
            }
            finally
            {
                factory.ReleaseController(controller);
            }
            
            
        }
    }
}
