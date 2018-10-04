using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Identity
{
    /// <summary>
    /// User authentication configuration settings, please refer to UserAuthenticationSettings.config file.
    /// </summary>
    public class UserAuthenticationSettings
    {
        /// <summary>
        /// Active Directory security group name that corresponds to Admin user role.
        /// </summary>
        public static string AdminADGroup
        {
            get { return GetValueFromConfig("AdminUserADGroupName"); }
        }

        /// <summary>
        /// Active Directory security group name that corresponds to ReadWriteUser role.
        /// </summary>
        public static string ReadWriteADGroup
        {
            get { return GetValueFromConfig("ReadWriteUserADGroupName"); }
        }

        /// <summary>
        /// Active Directory security group name that corresponds to ReadOnlyUser role.
        /// </summary>
        public static string ReadOnlyADGroup
        {
            get { return GetValueFromConfig("ReadOnlyUserADGroupName"); }
        }

        /// <summary>
        /// The cookie authentication expiration time in hours.
        /// </summary>
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