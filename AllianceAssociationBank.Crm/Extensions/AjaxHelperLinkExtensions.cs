using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace AllianceAssociationBank.Crm.Extensions
{
    using Helper = HtmlExtensionsHelper;

    public static class AjaxHelperLinkExtensions
    {
        public static MvcHtmlString RoleBasedRouteLink(this AjaxHelper ajaxHelper,
                                                       string linkText,
                                                       string routeName,
                                                       object routeValues,
                                                       AjaxOptions ajaxOptions,
                                                       string cssClass)
        {
            return ajaxHelper.RoleBasedRouteLink(linkText, routeName, routeValues, ajaxOptions, Helper.CreateHtmlAttributes(cssClass));
        }

        public static MvcHtmlString RoleBasedRouteLink(this AjaxHelper ajaxHelper,
                                                       string linkText,
                                                       string routeName,
                                                       object routeValues,
                                                       AjaxOptions ajaxOptions,
                                                       object htmlAttributes)
        {
            if (ajaxHelper.IsUserInEditRole())
            {
                return ajaxHelper.RouteLink(linkText, routeName, routeValues, ajaxOptions, htmlAttributes);
            }

            return ajaxHelper.RouteLink(linkText, 
                                        routeName, 
                                        HtmlHelper.AnonymousObjectToHtmlAttributes(routeValues), 
                                        ajaxOptions, 
                                        Helper.CreateHtmlAttributesForDisabledLink(htmlAttributes));
        }
    }
}