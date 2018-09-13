using AllianceAssociationBank.Crm.Constants;
using Microsoft.Owin.Security;
using System;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;

namespace AllianceAssociationBank.Crm.Identity
{
    public class ADAuthenticationService : IAuthenticationService
    {
        private PrincipalContext _principalContext;
        private IAuthenticationManager _authenticationManager;

        public ADAuthenticationService(PrincipalContext principalContext, IAuthenticationManager authenticationManager)
        {
            _principalContext = principalContext ?? throw new ArgumentNullException(nameof(principalContext));
            _authenticationManager = authenticationManager ?? throw new ArgumentNullException(nameof(authenticationManager));
        }

        public SignInResult PasswordSignIn(string userName, string password, bool isPersistent)
        {
            var isAuthenticated = false;
            UserPrincipal userPrincipal = null;

            try
            {
                userPrincipal = UserPrincipal.FindByIdentity(_principalContext, userName);
                if (userPrincipal != null)
                {
                    // TODO: probably have to use SSL here
                    isAuthenticated = _principalContext.ValidateCredentials(userName, password, ContextOptions.Negotiate);
                }
            }
            catch (Exception ex)
            {
                // TODO: need to log this
                return SignInResult.ErrorOccurred;
            }

            if (!isAuthenticated)
            {
                return SignInResult.InvalidCredentials;
            }

            if (userPrincipal.IsAccountLockedOut())
            {
                return SignInResult.Disabled;
            }

            if (userPrincipal.Enabled.HasValue && userPrincipal.Enabled.Value == false)
            {
                return SignInResult.Disabled;
            }

            if (IsAuthorized(userPrincipal))
            {
                var userIdentity = CreateUserIdentity(userPrincipal);

                _authenticationManager.SignOut(AuthenticationType.CrmApplicationCookie);
                _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, userIdentity);
            }

            return SignInResult.NotAuthorized;
        }

        private bool IsAuthorized(UserPrincipal userPrincipal)
        {
            var securityGroups = userPrincipal.GetAuthorizationGroups();
            if (securityGroups.Count() > 0)
            {
                // FOR DEVELOPMENT ONLY !!
                if (securityGroups.Any(g => g.Name == "Administrators"))
                {
                    return true;
                }
                // FOR DEVELOPMENT ONLY !!

                if (securityGroups.Any(g => g.Name == UserRoleName.ReadWriteUser))
                {
                    return true;
                }
                else if (securityGroups.Any(g => g.Name == UserRoleName.ReadOnlyUser))
                {
                    return true;
                }
            }

            return false;
        }

        private ClaimsIdentity CreateUserIdentity(UserPrincipal userPrincipal)
        {
            var identity = new ClaimsIdentity
            (
                AuthenticationType.CrmApplicationCookie, 
                ClaimsIdentity.DefaultNameClaimType, 
                ClaimsIdentity.DefaultRoleClaimType
            );

            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "Active Directory"));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userPrincipal.SamAccountName));
            identity.AddClaim(new Claim(ClaimTypes.Name, userPrincipal.SamAccountName));

            var securityGroups = userPrincipal.GetAuthorizationGroups();
            if (securityGroups.Any(g => g.Name == UserRoleName.ReadWriteUser))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, UserRoleName.ReadWriteUser));
            }
            else if (securityGroups.Any(g => g.Name == UserRoleName.ReadOnlyUser))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, UserRoleName.ReadOnlyUser));
            }

            // FOR DEVELOPMENT ONLY !!
            if (securityGroups.Any(g => g.Name == "Administrators"))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, UserRoleName.ReadWriteUser));
            }
            // FOR DEVELOPMENT ONLY !!

            return identity;
        }
    }
}