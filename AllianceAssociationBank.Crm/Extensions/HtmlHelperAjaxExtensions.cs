using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace AllianceAssociationBank.Crm.Extensions
{
    using Helper = HtmlExtensionsHelper;

    public static class HtmlHelperAjxExtensions
    {
        public static MvcHtmlString RoleBasedRouteLink(this AjaxHelper ajaxHelper,
                                                       string linkText, 
                                                       string routeName,
                                                       object routeValues,
                                                       AjaxOptions ajaxOptions, 
                                                       string cssClass)
        {
            if (ajaxHelper.IsUserAuthorizedToEdit())
            {
                return ajaxHelper.RouteLink(linkText, routeName, routeValues, ajaxOptions, Helper.CreateHtmlAttributes(cssClass));
            }

            return ajaxHelper.RouteLink(linkText, routeName, routeValues, ajaxOptions, Helper.CreateHtmlAttributesForDisabledLink(cssClass));
        }
    }
}