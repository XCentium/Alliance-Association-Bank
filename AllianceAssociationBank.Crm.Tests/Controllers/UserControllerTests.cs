using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.User;
using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Identity;
using AllianceAssociationBank.Crm.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Xunit;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using AllianceAssociationBank.Crm.Constants.Home;

namespace AllianceAssociationBank.Crm.Tests.Controllers
{
    public class UserControllerTests
    {
        private UserController _controller;
        private Mock<IAuthenticationService> _mockAuthService;
        private Mock<HttpRequestBase> _mockHttpRequest;

        private LoginViewModel loginViewModel;
        private bool isPersistent = true;

        public UserControllerTests()
        {
            _mockAuthService = new Mock<IAuthenticationService>();
            _controller = new UserController(_mockAuthService.Object);

            // Mock http context so http request object is not null
            _mockHttpRequest = new Mock<HttpRequestBase>();
            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.SetupGet(c => c.Request).Returns(_mockHttpRequest.Object);
            _controller.ControllerContext = new ControllerContext(mockHttpContext.Object, new RouteData(), _controller);

            loginViewModel = new LoginViewModel()
            {
                UserName = "CrmUser1",
                Password = "Pass01234!"
            };
        }

        [Fact]
        public void Login_ValidUserCredentials_ShouldReturnRedirectToRoute()
        {
            _mockAuthService
                .Setup(s => s.PasswordSignIn(loginViewModel.UserName, loginViewModel.Password, isPersistent))
                .Returns(SignInResult.Success);

            var result = _controller.Login(loginViewModel, null);

            var redirectResult = Assert.IsType<RedirectToRouteResult>(result);
            Assert.Equal(ControllerName.Home, redirectResult.RouteValues["controller"]);
            Assert.Equal(HomeControllerAction.Index, redirectResult.RouteValues["action"]);
        }

        [Fact]
        public void Login_InvalidUserCredentials_ShouldReturnViewResult()
        {
            _mockAuthService
                .Setup(s => s.PasswordSignIn(loginViewModel.UserName, loginViewModel.Password, isPersistent))
                .Returns(SignInResult.InvalidCredentials);

            var result = _controller.Login(loginViewModel, null);

            AssertHelper.AssertActionResult<ViewResult, LoginViewModel>(result, UserView.Login);
        }

        [Fact]
        public void Login_AuthenticatedUser_ShouldReturnRedirectToRoute()
        {
            _mockHttpRequest.SetupGet(r => r.IsAuthenticated).Returns(true);

            var result = _controller.Login(null);

            var redirectResult = Assert.IsType<RedirectToRouteResult>(result);
        }

        [Fact]
        public void Login_NotAuthenticatedUser_ShouldReturnViewResult()
        {
            _mockHttpRequest.SetupGet(r => r.IsAuthenticated).Returns(false);

            var result = _controller.Login(null);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            Assert.Equal(UserView.Login, viewResult.ViewName);
        }

        [Fact]
        public void Logout_ValidState_ShouldReturnRedirectToRoute()
        {
            var result = _controller.Logout();

            var redirectResult = Assert.IsType<RedirectToRouteResult>(result);
            Assert.Equal(ControllerName.User, redirectResult.RouteValues["controller"]);
            Assert.Equal(UserControllerAction.Login, redirectResult.RouteValues["action"]);
        }
    }
}
