using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CorujaPresentation.Controllers
{

    public class ErrorController : Controller
    {
       
        public PartialViewResult PageNotFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return PartialView();
        }

        public PartialViewResult CustomError()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return PartialView();
        }


        public PartialViewResult BadRequest ()
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return PartialView();
        }

        public PartialViewResult Unauthorized()
        {
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return PartialView();
        }

        public PartialViewResult Forbidden()
        {
            Response.StatusCode = (int)HttpStatusCode.Forbidden;
            return PartialView();
        }











    }
}