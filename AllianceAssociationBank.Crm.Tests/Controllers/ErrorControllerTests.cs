using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.ViewModels;
using Moq;
using Serilog;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Controllers
{
    public class ErrorControllerTests
    {
        private ErrorController _controller;
        private ILogger _logger;
        private Mock<HttpContextBase> _mockHttpContext;
        private string aspxerrorpath;

        private const string X_REQUEST_WITH = "X-Requested-With";
        private const string XML_HTTP_REQUEST = "XMLHttpRequest";

        public ErrorControllerTests()
        {
            _logger = new LoggerConfiguration().CreateLogger();
            _mockHttpContext = new Mock<HttpContextBase>();
            aspxerrorpath = "/Home/Index";

            _controller = new ErrorController(_logger);
            _controller.ControllerContext = new ControllerContext(_mockHttpContext.Object, new RouteData(), _controller);
        }

        [Fact]
        public void InternalError_StandardRequest_ShouldReturnViewErrorResult()
        {
            _mockHttpContext.Setup(c => c.Request[X_REQUEST_WITH]).Returns(string.Empty);

            var result = _controller.InternalError(aspxerrorpath);

            AssertHelper.AssertActionResult<ViewErrorResult, ErrorViewModel>(result, SharedView.Error);
        }

        [Fact]
        public void InternalError_AjaxRequest_ShouldReturnJsonErrorResult()
        {
            _mockHttpContext.Setup(c => c.Request[X_REQUEST_WITH]).Returns(XML_HTTP_REQUEST);

            var result = _controller.InternalError(aspxerrorpath);

            var viewResult = Assert.IsType<JsonErrorResult>(result);
            Assert.NotNull(viewResult);
        }

        [Fact]
        public void NotFound_StandardRequest_ShouldReturnViewErrorResult()
        {
            _mockHttpContext.Setup(c => c.Request[X_REQUEST_WITH]).Returns(string.Empty);

            var result = _controller.NotFound(aspxerrorpath);

            AssertHelper.AssertActionResult<ViewErrorResult, ErrorViewModel>(result, SharedView.Error);
        }

        [Fact]
        public void NotFound_AjaxRequest_ShouldReturnJsonErrorResult()
        {
            _mockHttpContext.Setup(c => c.Request[X_REQUEST_WITH]).Returns(XML_HTTP_REQUEST);

            var result = _controller.NotFound(aspxerrorpath);

            var viewResult = Assert.IsType<JsonErrorResult>(result);
            Assert.NotNull(viewResult);
        }
    }
}
