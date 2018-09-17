using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Extensions
{
    public static class HtmlExtensionsHelper
    {
        private const string DISABLED_CSS = "btn-link-disabled";

        public static object CreateHtmlAttributes(string cssClass, bool addDisabledAttribute = false)
        {
            if (addDisabledAttribute)
            {
                return new { @class = cssClass, disabled = "disabled" };
            }

            return new { @class = cssClass };
        }

        public static object CreateHtmlAttributesForDisabledLink(string cssClass)
        {
            return CreateHtmlAttributes((DISABLED_CSS + " " + cssClass).TrimEnd());
        }
    }
}