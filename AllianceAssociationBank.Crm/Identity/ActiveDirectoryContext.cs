using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;

namespace AllianceAssociationBank.Crm.Identity
{
    /// <summary>
    /// Active Directory context, encapsulates interaction with System.DirectoryServices.AccountManagement namespace.
    /// </summary>
    public class ActiveDirectoryContext : IActiveDirectoryContext
    {
        private PrincipalContext _principalContext;

        public ActiveDirectoryContext(PrincipalContext principalContext)
        {
            _principalContext = principalContext;
        }

        public UserPrincipal FindUserByName(string userName)
        {
            return UserPrincipal.FindByIdentity(_principalContext, userName);
        }

        public bool ValidateUserCredentials(string userName, string password)
        {
            return _principalContext.ValidateCredentials(userName, password);
        }

        public IEnumerable<Principal> GetUserSecurityGroups(UserPrincipal user)
        {
            return user.GetAuthorizationGroups().ToList();
        }
    }
}