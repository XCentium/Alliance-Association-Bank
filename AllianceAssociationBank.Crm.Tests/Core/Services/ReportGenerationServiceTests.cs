using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Core.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Core.Services
{
    public class ReportGenerationServiceTests
    {
        private IReportGenerationService _reportService;
        private Mock<IReportQueries> _mockReportQueries;
        private Mock<IFileSystemService> _mockFileSystem;
        private List<Project> _projects;

        public ReportGenerationServiceTests()
        {
            _mockReportQueries = new Mock<IReportQueries>();
            _mockFileSystem = new Mock<IFileSystemService>();
            _mockFileSystem.Setup(f => f.GetAppBaseDirectory()).Returns("/somepath");
            _reportService = new ReportGenerationService(_mockReportQueries.Object, _mockFileSystem.Object);

            _projects = new List<Project>()
            {
                new Project() { ID = 1, ProjectName = "Project 1" },
                new Project() { ID = 2, ProjectName = "Project 2" },
            };

        }

        [Fact]
        public async Task GenerateReportByName_BoardingReport_ShouldReturnReportViewer()
        {
            _mockFileSystem.Setup(f => f.IsFileExists(It.IsAny<string>())).Returns(true);
            _mockReportQueries.Setup(q => q.GetBoardingDataSetAsync()).ReturnsAsync(_projects);

            var reportViewer = await _reportService.GenerateReportByName(ReportName.Boarding);

            Assert.NotNull(reportViewer);
            Assert.NotEmpty(reportViewer.LocalReport.DataSources);
        }

        [Fact]
        public async Task GenerateReportByName_AchSpecReport_ShouldReturnReportViewer()
        {
            _mockFileSystem.Setup(f => f.IsFileExists(It.IsAny<string>())).Returns(true);
            var projectId = 99;
            var achReportDataset = new List<AchReportDatasetDto>()
            {
                new AchReportDatasetDto() { ID = 1, ProjectName = "ACH Report Project" }
            };
            _mockReportQueries.Setup(q => q.GetAchReportDataSetAsync(projectId)).ReturnsAsync(achReportDataset);

            var reportViewer = await _reportService.GenerateReportByName(ReportName.AchSpec, projectId);

            Assert.NotNull(reportViewer);
            Assert.NotEmpty(reportViewer.LocalReport.DataSources);
        }

        [Fact]
        public async Task GenerateReportByName_WrongReportName_ShouldReturnNull()
        {
            _mockFileSystem.Setup(f => f.IsFileExists(It.IsAny<string>())).Returns(false);

            var reportViewer = await _reportService.GenerateReportByName("IncorrectReport");

            Assert.Null(reportViewer);
        }

        [Theory]
        [InlineData(ReportName.CompletedAndHold)]
        [InlineData(ReportName.SoftwareTransition)]
        [InlineData(ReportName.CmcById)]
        [InlineData(ReportName.CmcByName)]
        [InlineData(ReportName.CDEmails)]
        [InlineData(ReportName.Coupon)]
        [InlineData(ReportName.AchInitialReview)]
        [InlineData(ReportName.AchSixMonthReview)]
        public async Task GenerateReportByName_ReportNameInlineData_ShouldReturnReportViewer(string reportName)
        {
            _mockFileSystem.Setup(f => f.IsFileExists(It.IsAny<string>())).Returns(true);

            var reportViewer = await _reportService.GenerateReportByName(reportName);

            Assert.NotNull(reportViewer);
            Assert.NotEmpty(reportViewer.LocalReport.DataSources);
        }
    }
}
