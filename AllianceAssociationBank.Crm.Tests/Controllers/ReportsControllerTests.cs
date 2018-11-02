using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Tests.Helpers;
using Microsoft.Reporting.WebForms;
using Moq;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Controllers
{
    public class ReportsControllerTests
    {
        private ReportsController controller;

        private Mock<IReportGenerationService> reportsServiceMock;

        public ReportsControllerTests()
        {
            reportsServiceMock = new Mock<IReportGenerationService>();

            controller = new ReportsController(reportsServiceMock.Object);
        }

        [Fact]
        public async Task ViewReport_BoardingReport_ShouldReturnViewResult()
        {
            var reportName = ReportName.Boarding;
            reportsServiceMock.Setup(r => r.GenerateReportByName(reportName, null)).ReturnsAsync(new ReportViewer());

            var result = await controller.ViewReport(reportName);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            Assert.Equal(ReportsView.ViewReport, viewResult.ViewName);
        }

        [Fact]
        public async Task ViewReport_InvalidReport_ShouldThrowHttpNotFoundException()
        {
            var reportName = "Wrong Report";
            reportsServiceMock.Setup(s => s.GenerateReportByName(reportName, null)).ReturnsAsync(null as ReportViewer);

            var exception = await Record.ExceptionAsync(() => controller.ViewReport(reportName));

            Assert.IsType<HttpNotFoundException>(exception);
            Assert.NotNull(exception);
        }
    }
}
