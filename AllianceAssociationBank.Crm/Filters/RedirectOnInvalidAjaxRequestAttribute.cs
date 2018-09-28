using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Projects;
using System.Web.Mvc;
using System.Web.Routing;

namespace AllianceAssociationBank.Crm.Filters
{
    public class RedirectOnInvalidAjaxRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest() && !filterContext.IsChildAction)
            {
                if (filterContext.ActionParameters.TryGetValue("projectId", out var projectId))
                {
                    var redirectToResult = new RedirectToRouteResult(new RouteValueDictionary(new
                    {
                        controller = ControllerName.Projects,
                        action = ProjectsControllerAction.Edit,
                        id = projectId
                    }));

                    filterContext.Result = redirectToResult;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}