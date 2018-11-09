using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Tests.TestHelpers
{
    public static class MockViewContextExtensions
    {
        public static void SetupHttpContextUserRole(this Mock<ViewContext> mockViewContext, string userRole)
        {
            mockViewContext.Setup(c => c.HttpContext.User.IsInRole(userRole)).Returns(true);
        }
    }
}
