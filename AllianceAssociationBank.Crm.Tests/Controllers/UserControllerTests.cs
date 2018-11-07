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
        private UserController controller;
        private Mock<IAuthenticationService> authServiceMock;
        private Mock<HttpRequestBase> httpRequest;

        private LoginViewModel loginViewModel;

        public UserControllerTests()
        {
            authServiceMock = new Mock<IAuthenticationService>();
            controller = new UserController(authServiceMock.Object);

            // Mock http context so http request object is not null
            httpRequest = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Request).Returns(httpRequest.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);

            loginViewModel = new LoginViewModel()
            {
                UserName = "CrmUser1",
                Password = "Pass01234!"
            };
        }

        [Fact]
        public void Login_ValidUserCredentials_ShouldReturnRedirectToRoute()
        {
            authServiceMock
                .Setup(s => s.PasswordSignIn(loginViewModel.UserName, loginViewModel.Password, false))
                .Returns(SignInResult.Success);

            var result = controller.Login(loginViewModel, null);

            var redirectResult = Assert.IsType<RedirectToRouteResult>(result);
            Assert.Equal(ControllerName.Home, redirectResult.RouteValues["controller"]);
            Assert.Equal(HomeControllerAction.Index, redirectResult.RouteValues["action"]);
        }

        [Fact]
        public void Login_InvalidUserCredentials_ShouldReturnViewResult()
        {
            authServiceMock
                .Setup(s => s.PasswordSignIn(loginViewModel.UserName, loginViewModel.Password, false))
                .Returns(SignInResult.InvalidCredentials);

            var result = controller.Login(loginViewModel, null);

            TestHelper.AssertActionResult<ViewResult, LoginViewModel>(result, UserView.Login);
        }

        [Fact]
        public void Login_AuthenticatedUser_ShouldReturnRedirectToRoute()
        {
            httpRequest.SetupGet(r => r.IsAuthenticated).Returns(true);

            var result = controller.Login(null);

            var redirectResult = Assert.IsType<RedirectToRouteResult>(result);
        }

        [Fact]
        public void Login_NotAuthenticatedUser_ShouldReturnViewResult()
        {
            httpRequest.SetupGet(r => r.IsAuthenticated).Returns(false);

            var result = controller.Login(null);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            Assert.Equal(UserView.Login, viewResult.ViewName);
        }

        [Fact]
        public void Logout_ValidState_ShouldReturnRedirectToRoute()
        {
            var result = controller.Logout();

            var redirectResult = Assert.IsType<RedirectToRouteResult>(result);
            Assert.Equal(ControllerName.User, redirectResult.RouteValues["controller"]);
            Assert.Equal(UserControllerAction.Login, redirectResult.RouteValues["action"]);
        }
    }
}
