using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorujaPresentation.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult Error(int statusCode, Exception exception)
        {
            Response.StatusCode = statusCode;
            ViewBag.StatusCode = statusCode + " Error";
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult InternalServer()
        {
            return View();
        }

    }
}