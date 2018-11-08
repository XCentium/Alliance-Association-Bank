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
    public class AjaxHelperAuthorizationExtensionsTests
    {
        private AjaxHelper ajaxHelper;

        private Mock<ViewContext> mockViewContext;
        private Mock<IViewDataContainer> mockViewDataContainer;

        public AjaxHelperAuthorizationExtensionsTests()
        {
            mockViewContext = new Mock<ViewContext>();
            mockViewDataContainer = new Mock<IViewDataContainer>();

            ajaxHelper = new AjaxHelper(mockViewContext.Object, mockViewDataContainer.Object);
        }

        [Fact]
        public void IsUserInEditRole_UserWithReadWriteRole_ShouldReturnTrue()
        {
            mockViewContext.SetupHttpContextUserRole(UserRole.ReadWriteUser);

            var result = ajaxHelper.IsUserInEditRole();

            Assert.True(result);
        }

        [Fact]
        public void IsUserInEditRole_UserWithReadOnlyRole_ShouldReturnFalse()
        {
            mockViewContext.SetupHttpContextUserRole(UserRole.ReadOnlyUser);

            var result = ajaxHelper.IsUserInEditRole();

            Assert.False(result);
        }
    }
}
