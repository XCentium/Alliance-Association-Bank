using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Constants
{
    public static class ValidationRegex
    {
        public const string PhoneNumber = @"^(1?)([ .-]?)\(?([0-9]{3})\)?([ .-]?)([0-9]{3})([ .-]?)([0-9]{4})(.*)";

        public const string UsaZipCode = @"^([0-9]{5})(-[0-9]{4}|[0-9]{4})?$";

        public const string TIN = @"^([0-9]{2})(-?)([0-9]{7})$";
    }
}