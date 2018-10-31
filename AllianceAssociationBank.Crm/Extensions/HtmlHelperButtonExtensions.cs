using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Extensions
{
    public static class HtmlHelperButtonExtensions
    {
        public static MvcHtmlString RoleBasedButton(this HtmlHelper htmlHelper, string buttonText, string buttonType, string cssClass, string title = null)
        {
            var tagBuilder = new TagBuilder("button");
            tagBuilder.InnerHtml = buttonText;
            tagBuilder.MergeAttribute("type", buttonType);
            tagBuilder.MergeAttribute("class", cssClass);
            if (!string.IsNullOrEmpty(title))
            {
                tagBuilder.MergeAttribute("title", title);
            }


            if (!htmlHelper.IsUserInEditRole())
            {
                tagBuilder.MergeAttribute("disabled", "disabled");
            }

            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }
}