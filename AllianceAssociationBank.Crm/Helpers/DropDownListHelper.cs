using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace AllianceAssociationBank.Crm.Helpers
{
    public class DropDownListHelper
    {
        public static IEnumerable<string> InstitutionValues
        {
            get { return GetValuesFromConfig("InstitutionValues"); }
        }

        public static IEnumerable<string> LockboxSystemValues
        {
            get { return GetValuesFromConfig("LockboxSystemValues"); }
        }

        public static IEnumerable<string> LockboxStatusValues
        {
            get { return GetValuesFromConfig("LockboxStatusValues"); }
        }

        public static IEnumerable<string> StatusValues
        {
            get { return GetValuesFromConfig("StatusValues"); }
        }

        public static IEnumerable<string> XmlUsageValues
        {
            get { return GetValuesFromConfig("XmlUsageValues"); }
        }

        private static IEnumerable<string> GetValuesFromConfig(string key)
        {
            var dropDownListSettings = 
                ConfigurationManager.GetSection("dropDownListSettings") as NameValueCollection;

            if (dropDownListSettings != null)
            {
                return (dropDownListSettings[key] ?? string.Empty)
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    .ToList();
            }

            return new List<string>();
        }
    }
}