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
        public ActionResult Roles()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);

        }
       
        [HttpPost]
        public ActionResult CreateRole(string newwRoleName)
        {
            var _newRoleName = newwRoleName;
            if (ModelState.IsValid)
            {

                if (roleManager.RoleExists(_newRoleName) == false)
                {
                    var role = new IdentityRole(_newRoleName);
                    roleManager.Create(role);
                }
                db.SaveChanges();

            }
            return RedirectToAction("Roles");
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
            return RedirectToAction("Roles");
        }

        /// //////////////////////////////////////////////////////////////

        public ActionResult ListOfUsers(int id)
        {


            return View();
        }

        //[HttpPost]
        //	public ActionResult ListOfUsersAction(string id)
        //	{
        //			var role = new IdentityRole();
        //		var users = role.Users.ToList();


        //		RedirectToAction("RoleManager");
        //	}



        //Usuários e Perfis ////////////////////////////////

        [ActionName("DeleteUser")]
        public ActionResult DeleteUserFromRole(string id)
        {
            return View();
        }

        [ActionName("DeleteUser")]
        [HttpPost]
        public ActionResult DeleteUserFromRoleConfirm(string id)
        {
            return View();
        }


        public ActionResult AddUserToRole(string id)
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
