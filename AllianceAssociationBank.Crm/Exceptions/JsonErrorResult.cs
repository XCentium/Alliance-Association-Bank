using AllianceAssociationBank.Crm.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Exceptions
{
    public class JsonErrorResult : JsonResult
    {
        private readonly HttpStatusCode _httpStatusCode;

        public JsonErrorResult(HttpStatusCode statusCode, string errorMessage)
            : this(statusCode: statusCode,
                   errorTitle: null,
                   errorMessage: errorMessage)
        {
        }

        public JsonErrorResult(HttpStatusCode statusCode, 
                               string errorTitle = null, 
                               string errorMessage = null) 
        {
            _httpStatusCode = statusCode;
            errorTitle = errorTitle ?? UserErrorContent.Title.GetByStatusCode(statusCode);
            errorMessage = errorMessage ?? UserErrorContent.Message.GetByStatusCode(statusCode);

            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Data = new
            {
                error = errorTitle,
                message = errorMessage
            };
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            context.RequestContext.HttpContext.Response.StatusCode = (int)_httpStatusCode;
            base.ExecuteResult(context);
        }
    }
}