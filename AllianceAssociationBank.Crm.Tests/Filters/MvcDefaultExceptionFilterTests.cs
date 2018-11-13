using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Filters;
using AllianceAssociationBank.Crm.Tests.TestHelpers.Constants;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Filters
{
    public class MvcDefaultExceptionFilterTests
    {
        private MvcDefaultExceptionFilter _exceptionFilter;
        private ExceptionContext _exceptionContext;
        private Mock<HttpContextBase> _mockHttpContext;

        public MvcDefaultExceptionFilterTests()
        {
            var logger = new LoggerConfiguration().CreateLogger();
            _mockHttpContext = new Mock<HttpContextBase>();
            var mockHttpRequest = new Mock<HttpRequestBase>();
            var mockHttpResponse = new Mock<HttpResponseBase>();
            _mockHttpContext.Setup(c => c.Request).Returns(mockHttpRequest.Object);
            _mockHttpContext.Setup(c => c.Response).Returns(mockHttpResponse.Object);
            var controllerContext = new ControllerContext(
                _mockHttpContext.Object, 
                new RouteData(), 
                new Mock<ControllerBase>().Object);

            _exceptionFilter = new MvcDefaultExceptionFilter(logger);
            _exceptionContext = new ExceptionContext(controllerContext, new Exception("An error occurred"));
        }

        [Fact]
        public void OnException_NonAjaxRequest_ShouldHandleExceptionAndReturnViewErrorResult()
        {
            _exceptionFilter.OnException(_exceptionContext);

            Assert.True(_exceptionContext.ExceptionHandled);
            Assert.IsType<ViewErrorResult>(_exceptionContext.Result);
        }

        [Fact]
        public void OnException_AjaxRequest_ShouldHandleExceptionAndReturnJsonErrorResult()
        {
            _mockHttpContext
                .Setup(c => c.Request[HttpRequestValue.XRequestWith])
                .Returns(HttpRequestValue.XmlHttpRequest);

            _exceptionFilter.OnException(_exceptionContext);

            Assert.True(_exceptionContext.ExceptionHandled);
            Assert.IsType<JsonErrorResult>(_exceptionContext.Result);
        }
    }
}
