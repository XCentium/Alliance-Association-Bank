using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using AllianceAssociationBank.Crm.Identity;
using AllianceAssociationBank.Crm.ViewModels;
using AllianceAssociationBank.Crm.Constants;
using System;
using AllianceAssociationBank.Crm.Constants.Home;
using AllianceAssociationBank.Crm.Constants.User;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private IAuthenticationService _authenticationService;

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
            return View(UserView.Login);
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            // isPersistent = true will create persistent auth cookie 
            var result = _authenticationService.PasswordSignIn(
                model.UserName, 
                model.Password, 
                UserAuthenticationSettings.UsePersistentCookie);

            switch (result)
            {
                case SignInResult.Success:
                    return RedirectToLocal(returnUrl);
                case SignInResult.NotAuthorized:
                    ModelState.AddModelError("", SignInErrorMessage.NotAuthorizedUser);
                    return View(UserView.Login, model);
                case SignInResult.Disabled:
                    ModelState.AddModelError("", SignInErrorMessage.DisabledUser);
                    return View(UserView.Login, model);
                case SignInResult.InvalidCredentials:
                case SignInResult.ErrorOccurred:
                default:
                    ModelState.AddModelError("", SignInErrorMessage.InvalidUserCredentials);
                    return View(UserView.Login, model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            _authenticationService.SignOut();
            return RedirectToAction(UserControllerAction.Login, ControllerName.User);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction(HomeControllerAction.Index, ControllerName.Home);
        }
    }
}