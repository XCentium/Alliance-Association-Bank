using AllianceAssociationBank.Crm.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class BaseViewModel
    {
        public UserRoleEnum CurrentUserRole
        {
            get
            {
                if (HttpContext.Current?.User == null)
                {
                    return UserRoleEnum.Unknown;
                }
                else if (HttpContext.Current.User.IsInRole(UserRoleName.ReadWriteUser))
                {
                    return UserRoleEnum.ReadWriteUser;
                }
                else
                {
                    return UserRoleEnum.ReadOnlyUser;
                }
            }    
        }
    }
}