using AllianceAssociationBank.Crm.Constants;
using Serilog;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace AllianceAssociationBank.Crm.Filters
{
    public class WebApiDefaultExceptionFilter : ExceptionFilterAttribute
    {
        private ILogger _logger;

        public WebApiDefaultExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            var httpStatusCode = context.Exception is HttpResponseException ?
                                 ((HttpResponseException)context.Exception).Response.StatusCode :
                                 HttpStatusCode.InternalServerError;

            var controllerName = context.ActionContext.ControllerContext.RouteData.Values["controller"] ?? "Unknown";

            _logger.Error(context.Exception,
                         $"An exception occured while executing a method in {controllerName} api controller.");

            context.Response = context.Request.CreateResponse(httpStatusCode, new
            {
                Error = UserErrorContent.Title.GetByStatusCode(httpStatusCode),
                Message = UserErrorContent.Message.GetByStatusCode(httpStatusCode)
            });

            base.OnException(context);
        }
    }
}