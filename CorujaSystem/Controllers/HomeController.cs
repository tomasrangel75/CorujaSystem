using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorujaSystem.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Parceiros()
        {
            return View();
        }

       
        public ActionResult Equipe()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            return View();
        }

        public ActionResult Conteudo()
        {
            return View();
        }

        public PartialViewResult SysError()
        {
            return PartialView();
        }
        

        public ActionResult Testes()
        {
            ViewBag.Msg = "<p>Email de confirmação enviado para <a >tomas@gmail.com.br</a> </p> <p>Verifique seu inbox e confirme seu endereço</p>";
            return View();
            
        }

    }

}