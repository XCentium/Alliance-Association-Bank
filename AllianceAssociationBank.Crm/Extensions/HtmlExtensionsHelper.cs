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
        private const string READ_ONLY_CSS = "read-only";
        private const string DISABLED_LINK_CSS = "btn-link-disabled";

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

        public static object CreateHtmlAttributesForReadOnly(string cssClass)
        {
            return CreateHtmlAttributes((READ_ONLY_CSS + " " + cssClass).TrimEnd());
        }

        public static object CreateHtmlAttributesForDisabledLink(string cssClass)
        {
            return CreateHtmlAttributes((DISABLED_LINK_CSS + " " + cssClass).TrimEnd());
        }

        public static RouteValueDictionary CreateHtmlAttributesForDisabledLink(object htmlAttributes)
        {
            var attributesDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            if (attributesDictionary.TryGetValue(CLASS, out var cssClass))
            {
                attributesDictionary[CLASS] = DISABLED_LINK_CSS + " " + cssClass;
            }
            else
            {
                attributesDictionary.Add(CLASS, DISABLED_LINK_CSS);
            }

            return attributesDictionary;
        }
    }
}