using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using AllianceAssociationBank.Crm.Identity;
using AllianceAssociationBank.Crm.Constants;
using System.Web.Helpers;
using System.Security.Claims;

namespace AllianceAssociationBank.Crm
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;

            // Enable the application to use a cookie to store information for the signed in user
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = AuthenticationType.CrmApplicationCookie,
                LoginPath = new PathString("/User/Login"),
                Provider = new CookieAuthenticationProvider(),
                CookieName = "Aab.Crm.ApplicationIdentity",
                CookieHttpOnly = true,
                CookieSecure = CookieSecureOption.SameAsRequest,
                ExpireTimeSpan = TimeSpan.FromHours(UserAuthenticationSettings.CookieAuthExpireHours)
                //,SlidingExpiration = false
            });
        }
    }
}