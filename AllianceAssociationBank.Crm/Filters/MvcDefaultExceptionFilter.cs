using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.ViewModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AllianceAssociationBank.Crm.Filters
{
    public class MvcDefaultExceptionFilter : FilterAttribute, IExceptionFilter
    {
        private ILogger _logger;

        public MvcDefaultExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext filterContext)
        {
            //if (filterContext.HttpContext.IsCustomErrorEnabled)
            //{
            //    return;
            //}

            if (filterContext.ExceptionHandled)
            {
                return;
            }

            var controllerName = filterContext.RouteData.Values["controller"] ?? "Unknown";
            var actionName = filterContext.RouteData.Values["action"] ?? "Unknown";
            var httpStatusCode = filterContext.Exception is HttpException ? 
                                 (HttpStatusCode)((HttpException)filterContext.Exception).GetHttpCode() :
                                 HttpStatusCode.InternalServerError;

            LogException(filterContext.Exception, httpStatusCode, (string)controllerName, (string)actionName);
            
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;

            filterContext.Result = GetErrorResult(filterContext.Exception, filterContext.HttpContext, httpStatusCode);
        }

        private void LogException(Exception exception, HttpStatusCode statusCode, string controllerName, string actionName)
        {
            switch (statusCode)
            {
                case HttpStatusCode.NotFound:
                    _logger.Warning($"{exception.GetType().Name} exception occured while executing {actionName} action " +
                                    $"in {controllerName} controller: {exception.Message}");
                    break;
                default:
                    _logger.Error(exception,
                                  $"An exception occured while executing {actionName} action in {controllerName} controller.");
                    break;
            }
        }

        private ActionResult GetErrorResult(Exception exception, HttpContextBase context, HttpStatusCode statusCode)
        {
            string errorMessage;

            // For internal server error return default error message instead of actual exception details
            if (statusCode == HttpStatusCode.InternalServerError)
            {
                errorMessage = DefaultErrorText.Message.InternalServerError;
            }
            else
            {
                errorMessage = exception.Message;
            }

            if (context.Request.IsAjaxRequest())
            {
                return new JsonErrorResult(statusCode, errorMessage: errorMessage);
            }
            else
            {
                return new ViewErrorResult(statusCode, errorMessage: errorMessage, httpRequest: context.Request);
            }
        }
    }
}