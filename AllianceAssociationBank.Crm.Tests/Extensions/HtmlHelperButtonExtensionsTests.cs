using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Extensions;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Extensions
{
    public class HtmlHelperButtonExtensionsTests
    {
        private HtmlHelper htmlHelper;

        private Mock<ViewContext> mockViewContext;
        private Mock<IViewDataContainer> mockViewDataContainer;

        private string disabledAttribute = @"disabled=""disabled""";

        public HtmlHelperButtonExtensionsTests()
        {
            mockViewContext = new Mock<ViewContext>(
                new Mock<ControllerContext>().Object,
                new Mock<IView>().Object,
                new ViewDataDictionary(),
                new TempDataDictionary(),
                TextWriter.Null);

            mockViewDataContainer = new Mock<IViewDataContainer>();

            htmlHelper = new HtmlHelper(mockViewContext.Object, mockViewDataContainer.Object);
        }

        [Fact]
        public void RoleBasedButton_UserWithAdminRole_ShouldReturnHtmlStringWithoutDisabledAttribute()
        {
            SetupUserRoleForViewContextMock(mockViewContext, UserRole.Admin);

            var result = htmlHelper.RoleBasedButton("SAVE", "submit", null);

            Assert.DoesNotContain(disabledAttribute, result.ToString());
        }

        [Fact]
        public void RoleBasedButton_UserWithReadWriteRole_ShouldReturnHtmlStringWithoutDisabledAttribute()
        {
            SetupUserRoleForViewContextMock(mockViewContext, UserRole.ReadWriteUser);

            var result = htmlHelper.RoleBasedButton("SAVE", "submit", null);

            Assert.DoesNotContain(disabledAttribute, result.ToString());
        }

        [Fact]
        public void RoleBasedButton_UserWithReadOnlyRole_ShouldReturnHtmlStringWithDisabledAttribute()
        {
            SetupUserRoleForViewContextMock(mockViewContext, UserRole.ReadOnlyUser);

            var result = htmlHelper.RoleBasedButton("SAVE", "submit", null);

            Assert.Contains(disabledAttribute, result.ToString());
        }

        private void SetupUserRoleForViewContextMock(Mock<ViewContext> viewContextMock, string userRole)
        {
            viewContextMock.Setup(c => c.HttpContext.User.IsInRole(userRole)).Returns(true);
        }
    }
}
