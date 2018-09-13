using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Constants
{
    public static class SignInErrorMessage
    {
        public const string InvalidUserCredentials = "Invalid login attempt. Please try again.";
        public const string NotAuthorizedUser = "You are not authorized to access this application. Please contact your administrator.";
        public const string DisabledUser = "Your account has been locked out or disabled. Please contact your administrator.";
    }
}