using AllianceAssociationBank.Crm.Constants;
using Microsoft.Owin.Security;
using System;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Claims;

namespace AllianceAssociationBank.Crm.Identity
{
    /// <summary>
    /// Active Directory authentication service
    /// </summary>
    public class ADAuthenticationService : IAuthenticationService
    {
        private PrincipalContext _principalContext;
        private IAuthenticationManager _authenticationManager;

        /// <summary>
        /// Initializes a new instance of ADAuthenticationService.
        /// </summary>
        /// <param name="principalContext">Active Directory principal context.</param>
        /// <param name="authenticationManager">Owin authentication middleware.</param>
        public ADAuthenticationService(PrincipalContext principalContext, IAuthenticationManager authenticationManager)
        {
            _principalContext = principalContext ?? throw new ArgumentNullException(nameof(principalContext));
            _authenticationManager = authenticationManager ?? throw new ArgumentNullException(nameof(authenticationManager));
        }

        /// <summary>
        /// Sign in a user using Active Directory username and password and create claims based user identity on success.
        /// </summary>
        /// <param name="userName">Active Directory username.</param>
        /// <param name="password">Active Directory password.</param>
        /// <param name="isPersistent">Should the authentication session be persisted across multiple requests.</param>
        /// <returns>Returns SignInResult enum with result.</returns>
        public SignInResult PasswordSignIn(string userName, string password, bool isPersistent)
        {
            var isAuthenticated = false;
            UserPrincipal userPrincipal = null;

            try
            {
                userPrincipal = UserPrincipal.FindByIdentity(_principalContext, userName);
                if (userPrincipal != null)
                {
                    isAuthenticated = _principalContext.ValidateCredentials(userName, password);
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

                return SignInResult.Success;
            }

            return SignInResult.NotAuthorized;
        }

        /// <summary>
        /// Check if a user is authorized to access the application, needs to belong to one of the security groups.
        /// </summary>
        /// <param name="userPrincipal">Active Directory user principal object.</param>
        /// <returns>Returns true if a user is in one of the specified security groups.</returns>
        private bool IsAuthorized(UserPrincipal userPrincipal)
        {
            var securityGroups = userPrincipal.GetAuthorizationGroups();
            if (securityGroups.Count() > 0)
            {
                // FOR DEVELOPMENT ONLY - TODO: NEED TO REMOVE THIS !!
                //if (securityGroups.Any(g => g.Name == "Administrators"))
                //{
                //    return true;
                //}

                if (securityGroups.Any(g => g.Name == UserAuthenticationSettings.AdminADGroup ||
                                            g.Name == UserAuthenticationSettings.ReadWriteADGroup || 
                                            g.Name == UserAuthenticationSettings.ReadOnlyADGroup))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Create new claims based user identity.
        /// </summary>
        /// <param name="userPrincipal">Active Directory user principal object.</param>
        /// <returns>Return a new ClaimsIdentity object for authenticated user.</returns>
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

            if (securityGroups.Any(g => g.Name == UserAuthenticationSettings.AdminADGroup))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, UserRole.Admin));
            }
            else if (securityGroups.Any(g => g.Name == UserAuthenticationSettings.ReadWriteADGroup))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, UserRole.ReadWriteUser));
            }
            else if (securityGroups.Any(g => g.Name == UserAuthenticationSettings.ReadOnlyADGroup))
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, UserRole.ReadOnlyUser));
            }

            // FOR DEVELOPMENT ONLY - TODO: NEED TO REMOVE THIS !!
            //if (securityGroups.Any(g => g.Name == "Administrators"))
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, UserRole.ReadWriteUser));
            //}

            return identity;
        }
    }
}