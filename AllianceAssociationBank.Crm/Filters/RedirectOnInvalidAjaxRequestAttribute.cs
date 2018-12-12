using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Projects;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace AllianceAssociationBank.Crm.Filters
{
    public class RedirectOnInvalidAjaxRequestAttribute : ActionFilterAttribute
    {
        public string ControllerName { get; }

        public string ActionName { get; }

        public string IdParameterName { get; }

        public RedirectOnInvalidAjaxRequestAttribute(string controller, string action, string idParameter = null)
        {
            ControllerName = controller ?? throw new ArgumentNullException("controller", "Value cannot be null.");
            ActionName = action ?? throw new ArgumentNullException("action", "Value cannot be null.");
            IdParameterName = idParameter;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest() && !filterContext.IsChildAction)
            {
                if (string.IsNullOrEmpty(IdParameterName))
                {
                    filterContext.Result = CreateRedirectResult();
                }
                else if (filterContext.ActionParameters.TryGetValue(IdParameterName, out var idParamValue))
                {
                    filterContext.Result = CreateRedirectResult(idParamValue);
                }
            }

            base.OnActionExecuting(filterContext);
        }

        private RedirectToRouteResult CreateRedirectResult(object idParamValue = null)
        {
            var routeValues = new RouteValueDictionary(new
            {
                controller = ControllerName,
                action = ActionName
            });

            if (idParamValue != null)
            {
                routeValues.Add("id", idParamValue);
            }

            return new RedirectToRouteResult(routeValues);
        }
    }
}