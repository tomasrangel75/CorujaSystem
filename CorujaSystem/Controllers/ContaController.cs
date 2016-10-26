using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CorujaSystem.Models;
using System.Collections.Generic;
using System.Data.Entity;
using CorujaSystem.VM;
using System.Security.Claims;
using CorujaSystem.DAL;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CorujaSystem.Controllers
{
    //[Authorize]
    public class ContaController : BaseController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext context;

        public ContaController()
        {
            context = new ApplicationDbContext();
        }

        public ContaController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }


            var us = UserManager.FindByEmail(model.Email);
            if (us == null)
            {
                ViewBag.Msg = "Usuário ou senha inválidos!";
                return View(model);
            }
            else { 
                    if (us.EmailConfirmed == false)
                    {
                        ViewBag.Msg = "Usuário com email não confirmado!";
                        return View(model);
                    }
            }

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:


                    var userLogged = context.Users.First(x => x.UserName.Equals(model.Email));
                    if (userLogged != null)
                    {
                        userLogged.LastLogin = DateTime.Now;
                        var entry = context.Entry(userLogged);
                        context.Users.Attach(userLogged);
                        entry.State = EntityState.Modified;
                        context.SaveChanges();
                    }


                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Tentativa de login inválida!");
                    ViewBag.Msg = "Usuário ou senha inválidos!";

                    return View(model);
            }
        }

        // /Account/Register
        [AllowAnonymous]
        public ActionResult Cadastro()
        {
            var model = new RegisterViewModel();
            var grads = GetLstGraduation();
            var sts = GetUfs();
            model.Grads = GetSelectListItems(grads);
            model.States = GetSelectListItems(sts);
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cadastro(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                //Select max(idUser) + 1 from AspNetUsers
                var maxIdUser = (from u in context.Users
                                 orderby u.IdUser descending
                                 select u).Take(1);
                int x = await context.Users.MaxAsync(y => y.IdUser);

                var newIdUser = x + 1;
                model.IdUser = newIdUser;


                ApplicationUser user = new ApplicationUser();
                IModelFactory mf = new ModelFactory();
                user = mf.Create(model);

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    UserManager.AddClaim(user.Id, new Claim(ClaimTypes.GivenName, model.FirstName));
                    UserManager.AddClaim(user.Id, new Claim(ClaimTypes.UserData, model.IdUser.ToString()));

                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmacaoEmail", "Conta",
                       new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id,
                       "Confirme sua conta", "Confirme sua conta clicando <a href=\""
                       + callbackUrl + "\">aqui</a>");
                    
                    ViewBag.Msg = "<p>Email de confirmação enviado para <span style = 'color:#EE573C'>" + user.Email.ToString() + "</span></p> <br> <p>Verifique seu inbox e confirme seu endereço</p>";
                   
                    return View("ShowMsg");
                }


                AddErrors(result);
            }

            var grads = GetLstGraduation();
            var sts = GetUfs();
            model.Grads = GetSelectListItems(grads);
            model.States = GetSelectListItems(sts);

            return View(model);
        }


        // /Account/Edit
        [AllowAnonymous]
        public ActionResult Dados()
        {

            var currentUser = User.Identity.GetUserName().ToString();
            var user = context.Users.First(u => u.UserName.Equals(currentUser));
            if (user == null)
            {
                return HttpNotFound();
            }

            EditViewModel model = new EditViewModel();
            IModelFactory mf = new ModelFactory();
            model = mf.CreateEdt(user);

            var grads = GetLstGraduation();
            var sts = GetUfs();
            model.Grads = GetSelectListItems(grads);
            model.States = GetSelectListItems(sts);

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Dados(EditViewModel model)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    var currentUser = context.Users.First(u => u.IdUser == model.IdUser);
                    currentUser.UserName = model.Email;

                    currentUser.UpdateDate = DateTime.Now;
                    currentUser.FirstName = model.FirstName;
                    currentUser.LastName = model.LastName;
                    currentUser.BirthDate = (model.BirthDate.HasValue) ? Convert.ToDateTime(model.BirthDate) : model.BirthDate;
                    currentUser.Cpf = model.Cpf;
                    currentUser.Rg = model.Rg;
                    currentUser.Graduation = model.Graduation;
                    currentUser.Cep = model.Cep;
                    currentUser.Address = model.Address;
                    currentUser.AddressNumber = model.AddressNumber;
                    currentUser.AddressDetail = model.AddressDetail;
                    currentUser.Nhood = model.Nhood;
                    currentUser.City = model.City;
                    currentUser.State = model.State;
                    currentUser.NewsLetter = model.NewsLetter;
                    currentUser.CellPhoneNumber = model.CellPhoneNumber;
                    currentUser.Email = model.Email;

                    var entry = context.Entry(currentUser);
                    context.Users.Attach(currentUser);
                    entry.State = EntityState.Modified;
                    context.SaveChanges();

                    RedirectToAction("Index", "Home");
                    return View("../Home/Index");

                }

            }
            catch (Exception exc)
            {
                ViewBag.Msg = "Erro ao atualizar dados, " + exc.Message.ToString();
                return View("ShowMsg");
            }


            var grads = GetLstGraduation();
            var sts = GetUfs();
            model.Grads = GetSelectListItems(grads);
            model.States = GetSelectListItems(sts);

            return View("Dados", model);

        }

        private IEnumerable<string> GetLstGraduation()
        {
            return new List<string>
            {
               "", "Ensino Fundamental", "Ensino Médio", "Superior Incompleto", "Superior Completo", "Pós-Graduação", "Mestrado", "Doutorado", "Superior em Andamento"
            };
        }

        private IEnumerable<string> GetUfs()
        {

            return new List<string>
            {
                "",
                "AC","AL","AP","AM","BA","CE","DF","ES","GO","MA","MT","MS","MG","PA","PB","PR","PE","PI","RJ",
                "RN","RS","RO","RR","SC","SP","SE","TO"
            };

        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }


        // /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmacaoEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmacaoEmail" : "Error");
        }

             // /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult LembrarSenha()
        {
            return View();
        }

        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LembrarSenha(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ConfirmacaoLembrarSenha");
                }

                //For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //Send an email with this link
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetSenha", "Conta", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Reset de Senha", "Para redefinir sua senha clique <a href=\"" + callbackUrl + "\">aqui</a>");
                return RedirectToAction("ConfirmacaoLembrarSenha", "Conta");


            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ConfirmacaoLembrarSenha()
        {
            return View();
        }

        // /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetSenha(string code)
        {
            return code == null ? View("Error") : View();
        }

        // /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetSenha(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ConfirmacaoResetSenha", "Conta");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ConfirmacaoResetSenha", "Conta");
            }
            AddErrors(result);
            return View();
        }

        // /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ConfirmacaoResetSenha()
        {
            return View();
        }


        // GET: /Conta/ChangePassword
        public ActionResult AlterarSenha()
        {
            return View();
        }


        // POST: /Conta/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AlterarSenha(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                ViewBag.Msg = "Senha Alterada com Sucesso";
                return View("ShowMsg");
            }

            AddErrors(result);

            return View(model);
        }


        //Account/LogOff    ********************************   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }






        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }

                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }

            }

            base.Dispose(disposing);
        }


        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion


        public ActionResult IndirectSeed()
        {

            // Role 
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (RoleManager.RoleExists("Admin") == false)
            {
                RoleManager.Create(new IdentityRole("Admin"));
            }

            if (RoleManager.RoleExists("Basico") == false)
            {
                RoleManager.Create(new IdentityRole("Basico"));
            }

            // User
            var PasswordHash = new PasswordHasher();


            var userUpdate = new ApplicationUser
            {
                // Add the following so our Seed data is complete:
                //Custom Fields //////////////////////////////////////////
                IdUser = 1,
                RegisterDate = DateTime.Now,
                FirstName = "Tomás",
                LastName = "Rangel",
                BirthDate = Convert.ToDateTime("10/05/1975"),
                Cpf = "278230298-12",
                Rg = "22174992-5",
                Graduation = "Malabarismo no sinal",
                Cep = "05376050",
                Address = "Rua Maso di Bianco",
                AddressNumber = "102",
                AddressDetail = "Barraco dos Fundos",
                Nhood = "Buraco fundo",
                City = "São Paulo",
                State = "SP",
                //Country = "BrasilVaronil",
                NewsLetter = true,
                //////////////////////////////////////////////////////////

                UserName = "tomas@devtomas.com.br",
                Email = "tomas@devtomas.com.br",
                PhoneNumber = "551100000000",
                CellPhoneNumber = "5511984076905",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = PasswordHash.HashPassword("C0ruj@2013"),
                UsedReport = 0,
                EmailConfirmed=true

            };

            context.Users.Add(userUpdate);

            context.SaveChanges();

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
             UserManager.AddToRole(userUpdate.Id, "Admin");

            //context.SaveChanges();

            return RedirectToAction("Home","Home");

        }


    }
}



