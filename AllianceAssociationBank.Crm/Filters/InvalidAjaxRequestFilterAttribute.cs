using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Filters
{
    public class InvalidAjaxRequestFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {

            }

            base.OnActionExecuting(filterContext);

            // TODO: need to implement this
            //if (!HttpContext.Request.IsAjaxRequest())
            //{
            //    return RedirectToAction(ProjectsControllerAction.Edit, ControllerName.Projects, new { id = projectId });
            //}

            //base.OnActionExecuting(actionContext);
        }
    }
}