using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AllianceAssociationBank.Crm;
using AllianceAssociationBank.Crm.Controllers;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ValidViewResult_NotNull()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.NotNull(result);
        }
    }
}
