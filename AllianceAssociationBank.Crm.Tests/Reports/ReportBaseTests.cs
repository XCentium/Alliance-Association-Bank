using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Reports;
using AllianceAssociationBank.Crm.Reports.Interfaces;
using Microsoft.Reporting.WebForms;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Reports
{
    public class ReportBaseTests
    {
        private Mock<IReportQueries> _queries;
        private Mock<IFileSystemService> _fileSystem;

        public ReportBaseTests()
        {
            _queries = new Mock<IReportQueries>();
            _fileSystem = new Mock<IFileSystemService>();
            _fileSystem.Setup(s => s.IsFileExists(It.IsAny<string>())).Returns(true);
        }

        [Theory]
        [InlineData(typeof(CmcByIdReport), ReportDatasetName.Master)]
        [InlineData(typeof(CmcByNameReport), ReportDatasetName.Master)]
        [InlineData(typeof(AchAllCompaniesReport), ReportDatasetName.Master)]
        [InlineData(typeof(CmcAddressByNameReport), ReportDatasetName.Master)]
        [InlineData(typeof(CmcByIdUsefulInfoReport), ReportDatasetName.Master)]
        public async Task ExecuteReport_InlineReportWithNoParams_ShouldSetReportDataSourceCorrectly(Type reportType, string dataSourceName)
        {
            var report = CreateReportInstance(reportType);

            await report.ExecuteReport();

            Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == dataSourceName);
            Assert.NotNull(report.ReportViewer);
        }

        [Theory]
        [InlineData(typeof(AchRiskInitialReport), ReportDatasetName.Master)]
        [InlineData(typeof(AchRisk6MonthReport), ReportDatasetName.Master)]
        [InlineData(typeof(AchRiskPost6MonthReport), ReportDatasetName.Master)]
        public async Task ExecuteReport_InlineReportWithProjectIdParam_ShouldSetReportDataSourceCorrectly(Type reportType, string dataSourceName)
        {
            var projectId = 99;
            var report = CreateReportInstance(reportType, projectId);

            await report.ExecuteReport();

            Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == dataSourceName);
            Assert.NotNull(report.ReportViewer);
        }

        [Theory]
        [InlineData(typeof(CmcByIdReport), ReportName.CmcById)]
        [InlineData(typeof(CmcByNameReport), ReportName.CmcByName)]
        [InlineData(typeof(AchAllCompaniesReport), ReportName.AchAllCompanies)]
        [InlineData(typeof(CmcAddressByNameReport), ReportName.CmcAddressByName)]
        [InlineData(typeof(CmcByIdUsefulInfoReport), ReportName.CmcByIdUsefulInfo)]
        public async Task ExecuteReport_InlineReportWithNoParams_ShouldSetDefinitionFileNameCorrectly(Type reportType, string definitionFileName)
        {
            var report = CreateReportInstance(reportType);

            await report.ExecuteReport();

            var reportBase = Assert.IsAssignableFrom<ReportBase>(report);
            Assert.Equal(definitionFileName, reportBase.ReportDefinitionFileName);
        }

        [Theory]
        [InlineData(typeof(AchRiskInitialReport), ReportName.AchRiskInitial)]
        [InlineData(typeof(AchRisk6MonthReport), ReportName.AchRiskSixMonth)]
        [InlineData(typeof(AchRiskPost6MonthReport), ReportName.AchRiskPostSixMonth)]
        public async Task ExecuteReport_InlineReportWithProjectIdParam_ShouldSetDefinitionFileNameCorrectly(Type reportType, string definitionFileName)
        {
            var projectId = 99;
            var report = CreateReportInstance(reportType, projectId);

            await report.ExecuteReport();

            var reportBase = Assert.IsAssignableFrom<ReportBase>(report);
            Assert.Equal(definitionFileName, reportBase.ReportDefinitionFileName);
        }

        [Fact]
        public void Constructor_BoardingReport_ShouldThrowInvalidReportException()
        {
            _fileSystem.Setup(s => s.IsFileExists(It.IsAny<string>())).Returns(false);

            var exception = Record.Exception(() => new BoardingReport(_queries.Object, _fileSystem.Object));

            Assert.NotNull(exception);
            Assert.IsType<InvalidReportException>(exception);
        }

        [Fact]
        public async Task ExecuteReport_BoardingReport_ShouldSetReportDataSourcesAndDefinitionFileNameCorrectly()
        {
            var report = new BoardingReport(_queries.Object, _fileSystem.Object);

            await report.ExecuteReport();

            Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == ReportDatasetName.Projects);
            Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == ReportDatasetName.Employees);
            Assert.Equal(ReportName.Boarding, report.ReportDefinitionFileName);
            Assert.NotNull(report.ReportViewer);
        }

        private IReport CreateReportInstance(Type reportType, int? projectId = null)
        {
            if (projectId.HasValue)
            {
                return (IReport)Activator.CreateInstance(reportType, projectId, _queries.Object, _fileSystem.Object);
            }

            return (IReport)Activator.CreateInstance(reportType, _queries.Object, _fileSystem.Object);
        }
    }
}
