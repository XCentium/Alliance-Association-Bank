using AllianceAssociationBank.Crm.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Extensions
{
    public static class HtmlHelperAuthorizationExtensions
    {
        public static bool IsUserAuthorizedToEdit(this HtmlHelper htmlHelper)
        {
            var currentUser = htmlHelper.ViewContext.HttpContext.User;

            if (currentUser?.IsInRole(UserRoleName.ReadWriteUser) ?? false)
            {
                return true;
            }

            return false;
        }
    }
}