using AllianceAssociationBank.Crm.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Extensions
{
    public static class HtmlHelperAuthorizationExtensions
    {
        public static bool IsUserAuthorizedToEdit(this HtmlHelper htmlHelper)
        {
            return IsUserInEditRole(htmlHelper.ViewContext.HttpContext.User);
        }

        public static bool IsUserAuthorizedToEdit(this AjaxHelper ajaxHelper)
        {
            return IsUserInEditRole(ajaxHelper.ViewContext.HttpContext.User);
        }

        private static bool IsUserInEditRole(IPrincipal contextUser)
        {
            if (contextUser?.IsInRole(UserRoleName.ReadWriteUser) ?? false)
            {
                return true;
            }

            return false;
        }
    }
}