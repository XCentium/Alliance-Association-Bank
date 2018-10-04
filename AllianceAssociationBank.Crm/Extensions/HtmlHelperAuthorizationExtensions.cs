using AllianceAssociationBank.Crm.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Extensions
{
    /// <summary>
    /// HtmlHelper and AjaxHelper authorization extensions that are used to determine user permissions
    /// </summary>
    public static class HtmlHelperAuthorizationExtensions
    {
        /// <summary>
        /// HtmlHelper extension to check if logged in user is authorized to edit data based on user role.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <returns>Returns true if user is authorized to edit data.</returns>
        public static bool IsUserAuthorizedToEdit(this HtmlHelper htmlHelper)
        {
            return IsUserInEditRole(htmlHelper.ViewContext.HttpContext.User);
        }

        /// <summary>
        /// AjaxHelper extension to check if logged in user is authorized to edit data based on user role.
        /// </summary>
        /// <param name="ajaxHelper"></param>
        /// <returns>Returns true if user is authorized to edit data.</returns>
        public static bool IsUserAuthorizedToEdit(this AjaxHelper ajaxHelper)
        {
            return IsUserInEditRole(ajaxHelper.ViewContext.HttpContext.User);
        }

        /// <summary>
        /// Check if logged in user belongs to one of Edit roles.
        /// </summary>
        /// <param name="contextUser">Logged in user IPrincipal object.</param>
        /// <returns>Returns true if user belongs to one of Edit roles.</returns>
        private static bool IsUserInEditRole(IPrincipal contextUser)
        {
            if (contextUser == null)
            {
                return false;
            }
            else if (contextUser.IsInRole(UserRole.Admin))
            {
                return true;
            }
            else if (contextUser.IsInRole(UserRole.ReadWriteUser))
            {
                return true;
            }

            return false;
        }
    }
}