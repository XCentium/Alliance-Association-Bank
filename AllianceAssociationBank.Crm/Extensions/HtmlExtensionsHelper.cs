using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AllianceAssociationBank.Crm.Extensions
{
    public static class HtmlExtensionsHelper
    {
        private const string CLASS = "class";
        private const string DISABLED_CSS = "btn-link-disabled";

        public static object CreateHtmlAttributes(string cssClass, bool addDisabledAttribute = false)
        {
            if (addDisabledAttribute)
            {
                return new { @class = cssClass, disabled = "disabled" };
            }

            return new { @class = cssClass };
        }

        public static RouteValueDictionary CreateHtmlAttributes(object htmlAttributes, bool addDisabledAttribute = false)
        {
            var attributesDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            if (addDisabledAttribute)
            {
                attributesDictionary.Add("disabled", "disabled");
            }

            return attributesDictionary;
        }

        public static object CreateHtmlAttributesForDisabledLink(string cssClass)
        {
            return CreateHtmlAttributes((DISABLED_CSS + " " + cssClass).TrimEnd());
        }

        public static RouteValueDictionary CreateHtmlAttributesForDisabledLink(object htmlAttributes)
        {
            var attributesDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            if (attributesDictionary.TryGetValue(CLASS, out var cssClass))
            {
                attributesDictionary[CLASS] = DISABLED_CSS + " " + cssClass;
            }
            else
            {
                attributesDictionary.Add(CLASS, DISABLED_CSS);
            }

            return attributesDictionary;
        }
    }
}