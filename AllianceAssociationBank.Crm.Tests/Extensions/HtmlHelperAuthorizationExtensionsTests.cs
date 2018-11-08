using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AllianceAssociationBank.Crm.Extensions;
using AllianceAssociationBank.Crm.Constants;
using Xunit;
using AllianceAssociationBank.Crm.Tests.TestHelpers;

namespace AllianceAssociationBank.Crm.Tests.Extensions
{
    public class HtmlHelperAuthorizationExtensionsTests
    {
        private HtmlHelper htmlHelper;

        private Mock<ViewContext> mockViewContext;
        private Mock<IViewDataContainer> mockViewDataContainer;

        public HtmlHelperAuthorizationExtensionsTests()
        {
            mockViewContext = new Mock<ViewContext>();
            mockViewDataContainer = new Mock<IViewDataContainer>();

            htmlHelper = new HtmlHelper(mockViewContext.Object, mockViewDataContainer.Object);
        }

        [Fact]
        public void IsUserInEditRole_UserWithReadWriteRole_ShouldReturnTrue()
        {
            mockViewContext.SetupHttpContextUserRole(UserRole.ReadWriteUser);

            var result = htmlHelper.IsUserInEditRole();

            Assert.True(result);
        }

        [Fact]
        public void IsUserInEditRole_UserWithReadOnlyRole_ShouldReturnFalse()
        {
            mockViewContext.SetupHttpContextUserRole(UserRole.ReadOnlyUser);

            var result = htmlHelper.IsUserInEditRole();

            Assert.False(result);
        }

        [Fact]
        public void IsUserInAdminRole_UserWithAdminRole_ShouldReturnTrue()
        {
            mockViewContext.SetupHttpContextUserRole(UserRole.Admin);

            var result = htmlHelper.IsUserInAdminRole();

            Assert.True(result);
        }

        [Fact]
        public void IsUserInAdminRole_UserWithReadWriteRole_ShouldReturnFalse()
        {
            mockViewContext.SetupHttpContextUserRole(UserRole.ReadWriteUser);

            var result = htmlHelper.IsUserInAdminRole();

            Assert.False(result);
        }
    }
}
