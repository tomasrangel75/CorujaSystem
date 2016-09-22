using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorujaPresentation.Areas.Especialista.Controllers
{
    public class AmbienteController : Controller
    {
        // GET: Especialista/HomeEspecialista
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Avaliacoes()
        {
            return View();
        }

        public ActionResult Relatorios()
        {
            return View();
        }

        public ActionResult Resultados()
        {
            return View();
        }

        public ActionResult Ajuda()
        {
            return View();
        }
       
    }
}