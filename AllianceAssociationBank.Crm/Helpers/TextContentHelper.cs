using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace AllianceAssociationBank.Crm.Helpers
{
    public class TextContentHelper
    {
        public static string LegalMessage
        {
            get { return GetValuesFromConfig("LegalMessage"); }
        }

        private static string GetValuesFromConfig(string key)
        {
            var appTextContentCollection = ConfigurationManager.GetSection("appTextContent") as NameValueCollection;

            if (appTextContentCollection != null)
            {
                return appTextContentCollection[key] ?? string.Empty;
            }

            return string.Empty;
        }
    }
}