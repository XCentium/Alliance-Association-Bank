﻿using AllianceAssociationBank.Crm.Constants;
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

        public JsonErrorResult(HttpStatusCode statusCode)
            : this(statusCode, DefaultErrorText.Title.GetByStatusCode(statusCode), DefaultErrorText.Message.GetByStatusCode(statusCode))
        {
        }

        public JsonErrorResult(HttpStatusCode statusCode, string errorMessage)
            : this(statusCode, DefaultErrorText.Title.GetByStatusCode(statusCode), errorMessage)
        {
        }

        public JsonErrorResult(HttpStatusCode statusCode, string errorTitle, string errorMessage) 
        {
            _httpStatusCode = statusCode;

            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            Data = new
            {
                error = errorTitle,
                message = errorMessage
            };
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.StatusCode = (int)_httpStatusCode;
            base.ExecuteResult(context);
        }
    }
}