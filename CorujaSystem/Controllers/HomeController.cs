using System;
using System.Collections.Generic;
using System.IO;
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
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Content/Files/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*");
            List<string> items = new List<string>();

            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }

            return View(items);
            
        }

        public FileResult Download(string ImageName)
        {
            return File("< your path >" +ImageName, System.Net.Mime.MediaTypeNames.Application.Octet);
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Files"), fileName);
                    file.SaveAs(path);
                }
                ViewBag.Message = "Upload successful";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("Uploads");
            }
        }


    }

}