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

namespace AllianceAssociationBank.Crm.Controllers
{
    // TODO: need to log exceptions here
    public class ErrorController : Controller
    {
        private ILogger _logger;

        public ErrorController(ILogger logger)
        {
            _logger = logger;
        }

        public ActionResult InternalError(string aspxerrorpath)
        {
            _logger.Error($"An unknown error occurred while processing the request to {aspxerrorpath}.");
            return GetErrorResult(HttpStatusCode.InternalServerError);
        }

        public ActionResult NotFound(string aspxerrorpath)
        {
            _logger.Warning($"A 404 error error occurred while processing the request to {aspxerrorpath}.");
            return GetErrorResult(HttpStatusCode.NotFound);
        }

        private ActionResult GetErrorResult(HttpStatusCode statusCode)
        {
            if (Request.IsAjaxRequest())
            {
                return new JsonErrorResult(statusCode);
            }
            else
            {
                return new ViewErrorResult(statusCode, httpContext: HttpContext);
            }
        }
    }
}