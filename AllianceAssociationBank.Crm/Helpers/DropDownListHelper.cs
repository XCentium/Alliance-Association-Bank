using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

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
            var values = ConfigurationManager.AppSettings[key] ?? string.Empty;

            return values.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToList();
        }
    }
}