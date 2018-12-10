using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Reports;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;
using Moq;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Controllers
{
    public class ReportsControllerTests
    {
        private ReportsController _controller;

        private Mock<IReportSelector> _mockReportsSelector;

        public ReportsControllerTests()
        {
            _mockReportsSelector = new Mock<IReportSelector>();

            _controller = new ReportsController(_mockReportsSelector.Object);

            // Mock http context so Http Request Url object is not null
            var mockHttpContext = new Mock<HttpContextBase>();
            var mockHttpRequest = new Mock<HttpRequestBase>();
            mockHttpContext.Setup(c => c.Request).Returns(mockHttpRequest.Object);
            mockHttpRequest.Setup(r => r.Url).Returns(new Uri("http://localhost"));
            _controller.ControllerContext = new ControllerContext(mockHttpContext.Object, new RouteData(), _controller);
        }

        [Fact]
        public void ViewReport_BoardingReport_ShouldReturnViewResult()
        {
            var reportName = ReportName.Boarding;
            var mockReport = new Mock<IReport>();
            _mockReportsSelector.Setup(r => r.IsReportExists(reportName)).Returns(true);

            var result = _controller.ViewReport(reportName);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            Assert.Equal(ReportsView.ViewReport, viewResult.ViewName);
        }

        [Fact]
        public void ViewReport_InvalidReport_ShouldThrowHttpNotFoundException()
        {
            var reportName = "Wrong-Name-Report";
            _mockReportsSelector.Setup(r => r.IsReportExists(reportName)).Returns(false);

            var exception = Record.Exception(() => _controller.ViewReport(reportName));

            Assert.IsType<HttpNotFoundException>(exception);
            Assert.NotNull(exception);
        }
    }
}
