using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Identity
{
    public class UserAuthenticationSettings
    {
        public static string AdminADGroup
        {
            get { return GetValueFromConfig("AdminUserADGroupName"); }
        }

        public static string ReadWriteADGroup
        {
            get { return GetValueFromConfig("ReadWriteUserADGroupName"); }
        }

        public static string ReadOnlyADGroup
        {
            get { return GetValueFromConfig("ReadOnlyUserADGroupName"); }
        }

        public static int CookieAuthExpireHours
        {
            get
            {
                if (int.TryParse(GetValueFromConfig("CookieAuthExpireHours"), out int hoursValue))
                {
                    return hoursValue;
                }

                return 12; // this is default
            }
        }

        private static string GetValueFromConfig(string key)
        {
            var userAuthenticationSettings = 
                ConfigurationManager.GetSection("userAuthenticationSettings") as NameValueCollection;

            if (userAuthenticationSettings != null)
            {
                return userAuthenticationSettings[key] ?? string.Empty;
            }

            return string.Empty;
        }
    }
}