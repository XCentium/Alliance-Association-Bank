using AllianceAssociationBank.Crm.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Identity
{
    public static class HtmlControlAuthorizationHandler
    {
        public static bool IsAuthorizedToEdit(UserRoleEnum currentUserRole)
        {
            if (currentUserRole == UserRoleEnum.ReadWriteUser)
            {
                return true;
            }

            return false;
        }
    }
}