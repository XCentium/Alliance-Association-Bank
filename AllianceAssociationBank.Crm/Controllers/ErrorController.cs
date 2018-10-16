using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    // TODO: need to log exceptions here
    public class ErrorController : Controller
    {
        public ActionResult InternalError(string aspxerrorpath)
        {
            return GetErrorResult(HttpStatusCode.InternalServerError);
        }

        public ActionResult NotFound(string aspxerrorpath)
        {
            return GetErrorResult(HttpStatusCode.NotFound);
        }

        private ActionResult GetErrorResult(HttpStatusCode statusCode)
        {
            var errorTitle = DefaultErrorText.Title.GetByStatusCode(statusCode);
            var errorMessage = DefaultErrorText.Message.GetByStatusCode(statusCode);
            var previousPageUrl = HttpContext.Request.UrlReferrer?.OriginalString;

            if (Request.IsAjaxRequest())
            {
                return new JsonErrorResult(statusCode, errorTitle, errorMessage);
            }
            else
            {
                return new ViewErrorResult(statusCode, errorTitle, errorMessage, previousPageUrl);
            }
        }
    }
}