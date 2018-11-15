using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Extensions
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string value, string compareToValue)
        {
            return value.Equals(compareToValue, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}