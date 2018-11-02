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

        public ViewErrorResult(HttpStatusCode statusCode, 
                               string errorTitle = null, 
                               string errorMessage = null, 
                               HttpRequestBase httpRequest = null)
        {
            _httpStatusCode = statusCode;
            errorTitle = errorTitle ?? DefaultErrorText.Title.GetByStatusCode(statusCode);
            errorMessage = errorMessage ?? DefaultErrorText.Message.GetByStatusCode(statusCode);

            var model = new ErrorViewModel
            (
                errorTitle,
                errorMessage,
                httpRequest?.UrlReferrer?.OriginalString ?? "/"
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