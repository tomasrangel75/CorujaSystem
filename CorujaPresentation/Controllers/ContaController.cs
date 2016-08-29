﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CorujaPresentation.Models;
using System.Collections.Generic;

namespace CorujaPresentation.Controllers
{
    [Authorize]
    public class ContaController : Controller
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

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Tentativa de login inválida");
                    return View(model);
            }
        }

        // /Account/Register
        [AllowAnonymous]
        public ActionResult Cadastro()
        {

            SelectListItem[] lst = new SelectListItem[]{
                                                new SelectListItem() {Text = "", Value="0"},
                                                new SelectListItem() {Text = "Ensino Fundamental", Value="1"},
                                                new SelectListItem() {Text = "Ensino Médio", Value="2"},
                                                new SelectListItem() {Text = "Superior Incompleto", Value="3"},
                                                new SelectListItem() {Text = "Superior Completo", Value="4"},
                                                new SelectListItem() {Text = "Pós-Graduação", Value="5"},
                                                new SelectListItem() {Text = "Mestrado", Value="6"},
                                                new SelectListItem() {Text = "Doutorado", Value="7"},
                                                new SelectListItem() {Text = "Superior em Andamento", Value="8"} };
            ViewBag.Lst = lst;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Cadastro(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    SecurityStamp = Guid.NewGuid().ToString(),

                    //Additional Fields
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = Convert.ToDateTime(model.BirthDate),
                    Cpf = model.Cpf,
                    Rg = model.Rg,
                    Graduation = model.Graduation,
                    Cep = model.Cep,
                    Address = model.Address,
                    AddressNumber = model.AddressNumber,
                    AddressDetail = model.AddressDetail,
                    Nhood = model.Nhood,
                    City = model.City,
                    State = model.State,
                    //Country = model.Country,
                    NewsLetter = model.NewsLetter,
                    CellPhoneNumber = model.CellPhoneNumber
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Loga novo usuário
                    // await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // Envia email de confirmação
                    string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Confirmação de Conta");
                    // Uncomment to debug locally 
                    //TempData["ViewBagLink"] = callbackUrl;

                    ViewBag.errorMessage = "Confirme se o Email foi enviado para o seu Inbox";
                    return View("ShowMsg");
                }


                AddErrors(result);
            }

            return View(model);
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
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        private async Task<string> SendEmailConfirmationTokenAsync(string userID, string subject)
        {
            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            // Send an email with this link:
            string code = await UserManager.GenerateEmailConfirmationTokenAsync(userID);
            var callbackUrl = Url.Action("ConfirmEmail", "Conta", new { userId = userID, code = code }, protocol: Request.Url.Scheme);
            await UserManager.SendEmailAsync(userID, subject, "Confirme sua conta clicando em <a href=\"" + callbackUrl + "\"></a>");


            return callbackUrl;
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
                await UserManager.SendEmailAsync(user.Id, "Reset de Senha", "Para redefinir sua senha clique <a href=\"" + callbackUrl + "\">here</a>");
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

        // /Account/LogOff
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
    }
}



