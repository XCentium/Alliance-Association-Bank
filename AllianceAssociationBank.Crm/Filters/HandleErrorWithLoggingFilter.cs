using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AllianceAssociationBank.Crm.Filters
{
    public class HandleErrorWithLoggingFilter : HandleErrorAttribute /*FilterAttribute, IExceptionFilter*/
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                return;
            }

            if (filterContext.ExceptionHandled)
            {
                return;
            }

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary()
            {
                { "controller", ControllerName.Error },
                { "action", (filterContext.Exception is HttpNotFoundException ? "NotFound" : "InternalServerError") },
                { "returnUrl",  filterContext.HttpContext.Request.UrlReferrer?.AbsolutePath }
            });


            //if (!filterContext.HttpContext.Request.IsAjaxRequest())
            //{
            //    var errorViewModel = new ErrorViewModel()
            //    {
            //        PreviousPageUrl = filterContext.HttpContext.Request.UrlReferrer?.AbsolutePath
            //    };

            //    if (filterContext.Exception is HttpNotFoundException)
            //    {
            //        errorViewModel.ErrorTitle = "Not Found";
            //        errorViewModel.ErrorMessage = "The resource you are looking for has been removed or is temporarily unavailable.";
            //    }
            //    else
            //    {
            //        errorViewModel.ErrorTitle = "Error";
            //        errorViewModel.ErrorMessage = "An error occurred while processing your request. Please try again later.";
            //    }

            //    filterContext.Result = new ViewResult()
            //    {
            //        ViewName = SharedView.Error,
            //        ViewData = new ViewDataDictionary<ErrorViewModel>(errorViewModel),
            //        TempData = filterContext.Controller.TempData
            //    };
            //}

            //filterContext.ExceptionHandled = true;
            //filterContext.HttpContext.Response.Clear();
            ////filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}