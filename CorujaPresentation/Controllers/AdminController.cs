using CorujaPresentation.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CorujaPresentation.Controllers
{
    public class AdminController : Controller
    {

        private ApplicationDbContext db;
        private RoleManager<IdentityRole> roleManager;

        public AdminController()
        {
            db = new ApplicationDbContext();
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
        }


        public ActionResult AdminCoruja()
        {
            return View();
        }

              // Perfis ///////////////////////////////////////////
        public ActionResult RoleList()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
            
        }

        public ActionResult CreateRole()
        {           
            var role = new IdentityRole();
            return View(role);
        }

        [HttpPost]
        public ActionResult CreateRole(IdentityRole newRole)
        {
            if (ModelState.IsValid)
            {
              
                if (roleManager.RoleExists(newRole.Name) == false)
                {
                    roleManager.Create(newRole);
                }
                db.SaveChanges();
                
            }
            return RedirectToAction("RoleList");
        }

        public ActionResult DeleteRole(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = roleManager.FindById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [HttpPost, ActionName("DeleteRole")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var role = roleManager.FindById(id);
            roleManager.Delete(role);
            db.SaveChanges();
            return RedirectToAction("RoleList");
        }

        public ActionResult RoleDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = roleManager.FindById(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }



        //Usuários e Perfis ////////////////////////////////

        public ActionResult AddUserToRole(string id)
        {
            ViewBag.Name = new SelectList(roleManager.Roles.ToList(), "Name", "Name");
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }


        public ActionResult DeleteUser(string id)
        {
            return View();
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
