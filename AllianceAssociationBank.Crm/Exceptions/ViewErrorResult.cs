using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Exceptions
{
    public class ViewErrorResult : ViewResult
    {
        private readonly HttpStatusCode _httpStatusCode;

        public ViewErrorResult(HttpStatusCode statusCode)
            : this(statusCode, 
                  DefaultErrorText.Title.GetByStatusCode(statusCode), 
                  DefaultErrorText.Message.GetByStatusCode(statusCode))
        {
        }

        public ViewErrorResult(HttpStatusCode statusCode, string errorMessage)
            : this(statusCode, 
                  DefaultErrorText.Title.GetByStatusCode(statusCode), errorMessage)
        {
        }

        public ViewErrorResult(HttpStatusCode statusCode, string errorTitle, string errorMessage, string previousPageUrl = null)
        {
            _httpStatusCode = statusCode;

            var model = new ErrorViewModel
            (
                errorTitle,
                errorMessage,
                previousPageUrl = string.IsNullOrEmpty(previousPageUrl) ? "/" : previousPageUrl
            );

            ViewName = SharedView.Error;
            ViewData = new ViewDataDictionary();
            ViewData.Model = model;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.StatusCode = (int)_httpStatusCode;
            base.ExecuteResult(context);
        }
    }
}