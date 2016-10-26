using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CorujaSystem;
using CorujaSystem.DAL;
using CorujaSystem.Models;

namespace CorujaSystem.Controllers
{
    public class UserFilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Especialista/UserFiles
        public ActionResult Index()
        {
            return View(db.UserFiles.ToList());
        }

        // GET: Especialista/UserFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFile userFile = db.UserFiles.Find(id);
            if (userFile == null)
            {
                return HttpNotFound();
            }
            return View(userFile);
        }

        // GET: Especialista/UserFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especialista/UserFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdUser,FileType,Name,Local,Extension,Size,Desc,DtUpload")] UserFile userFile)
        {
            if (ModelState.IsValid)
            {
                db.UserFiles.Add(userFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userFile);
        }

        // GET: Especialista/UserFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFile userFile = db.UserFiles.Find(id);
            if (userFile == null)
            {
                return HttpNotFound();
            }
            return View(userFile);
        }

        // POST: Especialista/UserFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdUser,FileType,Name,Local,Extension,Size,Desc,DtUpload")] UserFile userFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userFile);
        }

        // GET: Especialista/UserFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFile userFile = db.UserFiles.Find(id);
            if (userFile == null)
            {
                return HttpNotFound();
            }
            return View(userFile);
        }

        // POST: Especialista/UserFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserFile userFile = db.UserFiles.Find(id);
            db.UserFiles.Remove(userFile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
