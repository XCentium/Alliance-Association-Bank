using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using AllianceAssociationBank.Crm.Identity;
using AllianceAssociationBank.Crm.ViewModels;
using AllianceAssociationBank.Crm.Constants;
using System;
using AllianceAssociationBank.Crm.Constants.Home;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IAuthenticationService _authenticationService;

        public UserController()
        {
        }

        public UserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction(HomeControllerAction.Index, ControllerName.Home);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        //public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _authenticationService.PasswordSignIn(model.UserName, model.Password, false);

            switch (result)
            {
                case SignInResult.Success:
                    return RedirectToLocal(returnUrl);
                case SignInResult.NotAuthorized:
                    ModelState.AddModelError("", SignInErrorMessage.NotAuthorizedUser);
                    return View(model);
                case SignInResult.Disabled:
                    ModelState.AddModelError("", SignInErrorMessage.DisabledUser);
                    return View(model);
                case SignInResult.InvalidCredentials:
                case SignInResult.ErrorOccurred:
                default:
                    ModelState.AddModelError("", SignInErrorMessage.InvalidUserCredentials);
                    return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(AuthenticationType.CrmApplicationCookie);
            return RedirectToAction(HomeControllerAction.Index, ControllerName.Home);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (_userManager != null)
        //        {
        //            _userManager.Dispose();
        //            _userManager = null;
        //        }

        //        if (_signInManager != null)
        //        {
        //            _signInManager.Dispose();
        //            _signInManager = null;
        //        }
        //    }

        //    base.Dispose(disposing);
        //}

        #region Helpers
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(HomeControllerAction.Index, ControllerName.Home);
        }
        #endregion
    }
}