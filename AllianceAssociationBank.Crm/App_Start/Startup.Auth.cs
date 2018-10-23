using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using AllianceAssociationBank.Crm.Identity;
using AllianceAssociationBank.Crm.Constants;

namespace AllianceAssociationBank.Crm
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            //app.CreatePerOwinContext(CrmApplicationDbContext.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                //AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                AuthenticationType = AuthenticationType.CrmApplicationCookie,
                LoginPath = new PathString("/User/Login"),
                Provider = new CookieAuthenticationProvider(),
                //{
                //    // Enables the application to validate the security stamp when the user logs in.
                //    // This is a security feature which is used when you change a password or add an external login to your account.  
                //    //OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                //        validateInterval: TimeSpan.FromMinutes(30),
                //        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                //},
                CookieName = "Aab.Crm.ApplicationIdentity",
                ExpireTimeSpan = TimeSpan.FromHours(UserAuthenticationSettings.CookieAuthExpireHours)
            });
        }
    }
}