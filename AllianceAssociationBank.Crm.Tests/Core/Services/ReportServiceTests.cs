using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Services;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Reports;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Core.Services
{
    public class ReportServiceTests
    {
        private IReportService _reportService;

        private Mock<IReportSelector> _mockReportSelector;
        private Mock<IReportQueries> _mockReportQueries;
        private Mock<IFileSystemService> _mockFileSystemService;

        public ReportServiceTests()
        {
            _mockReportSelector = new Mock<IReportSelector>();

            _reportService = new ReportService(_mockReportSelector.Object);
            _mockReportQueries = new Mock<IReportQueries>();
            _mockFileSystemService = new Mock<IFileSystemService>();
        }

        [Fact]
        public async Task GenerateReportByName_BoardingReport_ShouldReturnIReport()
        {
            var reportName = ReportName.Boarding;
            _mockFileSystemService.Setup(f => f.IsFileExists(It.IsAny<string>())).Returns(true);
            _mockReportSelector
                .Setup(s => s.ResolveByName(reportName))
                .Returns(new BoardingReport(_mockReportQueries.Object, _mockFileSystemService.Object));

            var result = await _reportService.GenerateReportByName(reportName);

            Assert.IsAssignableFrom<IReport>(result);
        }

        [Fact]
        public async Task GenerateReportByName_AchSpecReport_ShouldReturnIReport()
        {
            var reportName = ReportName.AchSpec;
            var projectId = 999;
            _mockFileSystemService.Setup(f => f.IsFileExists(It.IsAny<string>())).Returns(true);
            _mockReportSelector
                .Setup(s => s.ResolveByName(reportName, projectId))
                .Returns(new AchSpecReport(projectId, _mockReportQueries.Object, _mockFileSystemService.Object));

            var result = await _reportService.GenerateReportByName(reportName, projectId);

            Assert.IsAssignableFrom<IReport>(result);
        }

        [Fact]
        public async Task GenerateReportByName_InvalidReport_ShouldThrowInvalidReportException()
        {
            var reportName = "Some-Wrong-Report";
            _mockReportSelector.Setup(s => s.ResolveByName(reportName)).Throws(new InvalidReportException());

            var exception = await Record.ExceptionAsync(() => _reportService.GenerateReportByName(reportName));

            Assert.IsType<InvalidReportException>(exception);
        }
    }
}
