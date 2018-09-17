using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Extensions
{
    public static class HtmlHelperButtonExtensions
    {
        public static MvcHtmlString RoleBasedButton(this HtmlHelper htmlHelper, string buttonText, string buttonType, string cssClass)
        {
            var tagBuilder = new TagBuilder("button");
            tagBuilder.InnerHtml = buttonText;
            tagBuilder.MergeAttribute("type", buttonType);
            tagBuilder.MergeAttribute("class", cssClass);

            if (!htmlHelper.IsUserAuthorizedToEdit())
            {
                tagBuilder.MergeAttribute("disabled", "disabled");
            }

            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }
}