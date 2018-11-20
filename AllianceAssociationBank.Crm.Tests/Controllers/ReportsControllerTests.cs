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
        private Mock<IReportGenerationService> _mockReportsService;

        public ReportsControllerTests()
        {
            _mockReportsSelector = new Mock<IReportSelector>();
            _mockReportsService = new Mock<IReportGenerationService>();

            _controller = new ReportsController(_mockReportsSelector.Object, _mockReportsService.Object);
        }

        [Fact]
        public async Task ViewReport_BoardingReport_ShouldReturnViewResult()
        {
            var reportName = ReportName.Boarding;
            var mockReport = new Mock<IReport>();
            _mockReportsSelector.Setup(r => r.ResolveByName(reportName)).Returns(mockReport.Object);

            var result = await _controller.ViewReport(reportName);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            Assert.Equal(ReportsView.ViewReport, viewResult.ViewName);
        }

        [Fact]
        public async Task ViewReport_InvalidReport_ShouldThrowHttpNotFoundException()
        {
            var reportName = "Wrong-Name-Report";
            _mockReportsSelector.Setup(s => s.ResolveByName(reportName)).Throws(new InvalidReportException());

            var exception = await Record.ExceptionAsync(() => _controller.ViewReport(reportName));

            Assert.IsType<HttpNotFoundException>(exception);
            Assert.NotNull(exception);
        }
    }
}
