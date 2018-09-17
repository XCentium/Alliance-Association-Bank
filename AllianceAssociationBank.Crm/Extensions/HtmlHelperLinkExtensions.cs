using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AllianceAssociationBank.Crm.Extensions
{
    using Helper = HtmlExtensionsHelper;

    public static class HtmlHelperLinkExtensions
    {
        public static MvcHtmlString RoleBasedActionLink(this HtmlHelper html, 
                                                        string linkText, 
                                                        string actionName, 
                                                        string controllerName, 
                                                        object routeValues,
                                                        string cssClass)
        {
            if (html.IsUserAuthorizedToEdit())
            {
                return html.ActionLink(linkText, actionName, controllerName, routeValues, Helper.CreateHtmlAttributes(cssClass));
            }

            return html.ActionLink(linkText, actionName, controllerName, routeValues, Helper.CreateHtmlAttributesForDisabledLink(cssClass));
        }
    }
}