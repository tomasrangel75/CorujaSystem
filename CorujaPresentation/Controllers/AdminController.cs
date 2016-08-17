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

        public ActionResult Index()
        {
            return View();
        }

        // Perfis ///////////////////////////////////////////
        public ActionResult RoleList()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
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

        public ActionResult Delete(string id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var role = roleManager.FindById(id);
            roleManager.Delete(role);
            db.SaveChanges();
            return RedirectToAction("RoleList");
        }

        //Usuários //////////////////////////////////////////
        public ActionResult UserList()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }

        public ActionResult UserDetails(string id)
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }


        //Usuários e Perfis ////////////////////////////////
        public ActionResult DefineUserRoles(string id)
        {
            ViewBag.Name = new SelectList(roleManager.Roles.ToList(), "Name", "Name");
            var roles = roleManager.Roles.ToList();
            return View(roles);
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
