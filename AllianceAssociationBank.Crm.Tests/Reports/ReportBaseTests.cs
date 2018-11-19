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
        [InlineData(typeof(AchAllCompaniesReport), ReportDatasetName.Master)]
        [InlineData(typeof(CmcAddressByNameReport), ReportDatasetName.Master)]
        [InlineData(typeof(CmcByIdUsefulInfoReport), ReportDatasetName.Master)]
        public async Task ExecuteReport_InlineReportType_ShouldSetReportDataSourceCorrectly(Type reportType, string dataSourceName)
        {
            var report = CreateReportInstance(reportType);

            await report.ExecuteReport();

            Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == dataSourceName);
            Assert.NotNull(report.ReportViewer);
        }

        [Theory]
        [InlineData(typeof(AchAllCompaniesReport), ReportName.AchAllCompanies)]
        [InlineData(typeof(CmcAddressByNameReport), ReportName.CmcAddressByName)]
        [InlineData(typeof(CmcByIdUsefulInfoReport), ReportName.CmcByIdUsefulInfo)]
        public async Task ExecuteReport_InlineReportType_ShouldSetReportDefinitionFileNameCorrectly(Type reportType, string definitionFileName)
        {
            var report = CreateReportInstance(reportType);

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
        public async Task ExecuteReport_BoardingReport_ShouldSetReportDataSourcesAndDefinitionFileCorrectly()
        {
            var report = new BoardingReport(_queries.Object, _fileSystem.Object);

            await report.ExecuteReport();

            Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == ReportDatasetName.Projects);
            Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == ReportDatasetName.Employees);
            Assert.Equal(ReportName.Boarding, report.ReportDefinitionFileName);
            Assert.NotNull(report.ReportViewer);
        }

        private IReport CreateReportInstance(Type reportType)
        {
            return (IReport)Activator.CreateInstance(reportType, _queries.Object, _fileSystem.Object);
        }
    }
}
