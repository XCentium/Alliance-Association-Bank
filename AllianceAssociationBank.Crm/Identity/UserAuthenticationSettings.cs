using System.Collections.Specialized;
using System.Configuration;

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
        public static string AdminADGroup => GetValueFromConfig("AdminUserADGroupName");

        /// <summary>
        /// Active Directory security group name that corresponds to ReadWriteUser role.
        /// </summary>
        public static string ReadWriteADGroup => GetValueFromConfig("ReadWriteUserADGroupName");

        /// <summary>
        /// Active Directory security group name that corresponds to ReadOnlyUser role.
        /// </summary>
        public static string ReadOnlyADGroup => GetValueFromConfig("ReadOnlyUserADGroupName");

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

        /// <summary>
        /// Boolean identifier if authentication session should be persisted across multiple requests.
        /// </summary>
        public static bool UsePersistentCookie
        {
            get
            {
                if (bool.TryParse(GetValueFromConfig("UsePersistentCookie"), out bool value))
                {
                    return value;
                }

                return true; // this is default
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