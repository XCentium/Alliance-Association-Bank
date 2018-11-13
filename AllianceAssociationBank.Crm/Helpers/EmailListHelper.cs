using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Helpers
{
    public class EmailListHelper
    {
        public static string Concatenate(IEnumerable<string> emails)
        {
            var validEmails = emails.Where(e => !string.IsNullOrEmpty(e));

            return string.Join("; ", validEmails);
        }
    }
}