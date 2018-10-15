using AllianceAssociationBank.Crm.Constants;
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
            var errorTitle = "!Error";
            var errorMessage = "!An error occurred while processing your request. Please try again later.";

            return GetErrorResult(HttpStatusCode.InternalServerError, errorTitle, errorMessage, aspxerrorpath);
        }

        public ActionResult NotFound(string aspxerrorpath)
        {
            var errorTitle = "Non Found";
            var errorMessage = "The resource you are looking for has been removed or is temporarily unavailable.";

            return GetErrorResult(HttpStatusCode.InternalServerError, errorTitle, errorMessage, aspxerrorpath);
        }

        //public ActionResult BadRequest()
        //{
        //    return View();
        //}

        private ActionResult GetErrorResult(HttpStatusCode statusCode, 
                                            string errorTitle, 
                                            string errorMessage, 
                                            string errorPath)
        {
            Response.StatusCode = (int)statusCode;

            if (Request.IsAjaxRequest())
            {
                //return new HttpStatusCodeResult(statusCode);
                var jsonResult = new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        error = errorTitle,
                        message = errorMessage
                    }
                };

                return jsonResult;
            }
            else
            {
                var errorModel = new ErrorViewModel
                (
                    errorTitle,
                    errorMessage,
                    HttpContext.Request.UrlReferrer?.OriginalString
                );

                //Response.StatusCode = (int)statusCode;
                return View(SharedView.Error, errorModel);
            }
        }
    }
}