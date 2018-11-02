using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace AllianceAssociationBank.Crm.Identity
{
    /// <summary>
    /// Active Directory context, encapsulates interaction with System.DirectoryServices.AccountManagement namespace.
    /// </summary>
    public interface IActiveDirectoryContext
    {
        UserPrincipal FindUserByName(string userName);
        bool ValidateUserCredentials(string userName, string password);
        IEnumerable<Principal> GetUserSecurityGroups(UserPrincipal user);
    }
}