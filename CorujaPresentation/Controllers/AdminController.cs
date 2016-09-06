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
        public ActionResult CreateRole(string Name)
        {

            try
            {
                var _newRoleName = Name;

                if (roleManager.RoleExists(_newRoleName) )
                {
                    var role = new IdentityRole(_newRoleName);
                    roleManager.Create(role);
                }
                db.SaveChanges();
                TempData["ResultMessage"] = "Perfil criado com sucesso!";
        
            }
            catch (Exception exc)
            {
                TempData["ResultMessage"] = exc.Message.ToString();
            }
      
            return RedirectToAction("Roles");
        }

        public ActionResult DeleteRole(string id)
        {
            try
            {
                var role = roleManager.FindById(id);
                roleManager.Delete(role);
                db.SaveChanges();
                TempData["ResultMessage"] = "Perfil excluído com sucesso!";
            }
            catch (Exception exc)
            {
                TempData["ResultMessage"] = exc.Message.ToString();

            }
           
            return RedirectToAction("Roles");
        }

        public ActionResult ListOfUsers(string roleName)
        {

            var role = db.Roles.Where(r => r.Name.Equals(roleName));
            var roleId = role.First().Id;
            var allUsers =
                       from roleUsers in db.Users
                       orderby roleUsers.FirstName, roleUsers.LastName
                       where roleUsers.Roles.Any(r => r.RoleId.Equals(roleId))
                       select new RoleUsers { UserMail = roleUsers.Email, UserName = roleUsers.FirstName + " " + roleUsers.LastName };

            return View(allUsers);

        } 
        
        // Usuarios ////////////////////////////////////////

        public ActionResult SysUsers()
        {
            var allUsers = db.Users.ToList();
            return View(allUsers);

        }

        public ActionResult SysUserDetails(string userEmail)
        {
            var selectedUser = db.Users.Select(x => x.Email.Equals(userEmail));

            return View(selectedUser);
        }

        //Usuários e Perfis ////////////////////////////////

        public ActionResult DefineUserRoles()
        {
            // prepopulat roles for the view dropdown
            var lst = db.Roles.OrderBy(r => r.Name).ToList().Select(rl =>
            new SelectListItem { Value = rl.Name.ToString(), Text = rl.Name }).ToList();
            ViewBag.Roles = lst;

            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var account = new ContaController();
            account.UserManager.AddToRole(user.Id, RoleName);

            ViewBag.ResultMessage = "Perfil criado com sucesso";

            // prepopulat roles for the view dropdown
            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return View("DefineUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var account = new ContaController();

                ViewBag.RolesForThisUser = account.UserManager.GetRoles(user.Id);

                // prepopulat roles for the view dropdown
                var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = list;
            }

            return View("DefineUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            var account = new ContaController();
            ApplicationUser user = db.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            if (account.UserManager.IsInRole(user.Id, RoleName))
            {
                account.UserManager.RemoveFromRole(user.Id, RoleName);
                ViewBag.ResultMessage = "Perfil removido com successo";
            }
            else
            {
                ViewBag.ResultMessage = "Esse usuário não pertence ao perfil selecionado";
            }
            // prepopulat roles for the view dropdown
            var list = db.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = list;

            return View("DefineUserRoles");
        }


       

        public ActionResult ExcludeFromRole(string id)
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
