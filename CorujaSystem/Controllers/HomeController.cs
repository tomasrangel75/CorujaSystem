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
        

    
        /// //////////////////////////////////////////////////////////////////////////////////////
     
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

        /*
        
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

            

        public List<UploadFileResult> ListaArquivos()
        {
            List<UploadFileResult> lstArquivos = new List<UploadFileResult>();
            DirectoryInfo dirInfo = new DirectoryInfo(Server.MapPath("~/Content/Uploads"));

            int i = 0;
            foreach (var item in dirInfo.GetFiles())
            {
                lstArquivos.Add(new UploadFileResult()
                {
                    IDArquivo = i + 1,
                    Nome = item.Name,
                    Caminho = dirInfo.FullName + @"\" + item.Name
                });
                i = i + 1;
            }
            return lstArquivos;
        }

        UploadFileResult oModelArquivos = new UploadFileResult();


        public ActionResult Index()
        {
            var _arquivos = oModelArquivos.ListaArquivos();
            return View(_arquivos);
        }

        public FileResult Download(string id)
        {
            int _arquivoId = Convert.ToInt32(id);
            var arquivos = oModelArquivos.ListaArquivos();

            string nomeArquivo = (from arquivo in arquivos
                                  where arquivo.IDArquivo == _arquivoId
                                  select arquivo.Caminho).First();

            string contentType = "application/pdf";
            return File(nomeArquivo, contentType, "Report.pdf");
        }


        public FileResult Download(string id)
        {
            int _arquivoId = Convert.ToInt32(id);
            string contentType = "";
            var arquivos = oModelArquivos.ListaArquivos(Server.MapPath("~/Content/Uploads"));
            
            string nomeArquivo = (from arquivo in arquivos
                                  where arquivo.IDArquivo == _arquivoId
                                  select arquivo.Caminho).First();

            string extensao = Path.GetExtension(nomeArquivo);
            
            string nomeArquivoV = Path.GetFileNameWithoutExtension(nomeArquivo);
            
            if (extensao.Equals(".pdf"))
                contentType = "application/pdf";
            
            if (extensao.Equals(".JPG") || extensao.Equals(".GIF") || extensao.Equals(".PNG"))
                contentType = "application/image";
            return File(nomeArquivo, contentType, nomeArquivoV + extensao);
        }
        */



        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(string baseData)
        {
            if (HttpContext.Request.Files.AllKeys.Any())
            {
                for (int i = 0; i <= HttpContext.Request.Files.Count; i++)
                {
                    var file = HttpContext.Request.Files["files" + i];
                    if (file != null)
                    {
                        var fileSavePath = Path.Combine(Server.MapPath("/Content/Files"), file.FileName);
                        file.SaveAs(fileSavePath);
                    }
                }
            }
            return View();
        }

        public ActionResult Download()
        {
            string[] files = Directory.GetFiles(Server.MapPath("/Content/Files"));
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = Path.GetFileName(files[i]);
            }
            ViewBag.Files = files;
            return View();
        }

        public FileResult DownloadFile(string fileName)
        {
            var filepath = System.IO.Path.Combine(Server.MapPath("/Content/Files/"), fileName);
            return File(filepath, MimeMapping.GetMimeMapping(filepath), fileName);
        }


    }

}