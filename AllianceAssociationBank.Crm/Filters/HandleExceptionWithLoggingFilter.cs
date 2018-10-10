using AllianceAssociationBank.Crm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Filters
{
    public class HandleErrorWithLoggingAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //TODO: Need to actually log the exceptions here
            System.Diagnostics.Debug.WriteLine(filterContext.Exception.Message);

            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary<ErrorViewModel>(new ErrorViewModel()
                    {
                        PreviousPageUrl = filterContext.HttpContext.Request.UrlReferrer.AbsolutePath
                    }),
                    TempData = filterContext.Controller.TempData
                };
            }

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}