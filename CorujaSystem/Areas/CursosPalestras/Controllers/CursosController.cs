using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CorujaSystem.Areas.CursosPalestras.Controllers
{
    public class CursosController : Controller
    {
        // GET: CursosPalestras/Cursos
        public ActionResult Index()
        {
            return View();
        }
    }
}