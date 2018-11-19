using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Reports;
using Microsoft.Reporting.WebForms;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public async Task ExecuteReport_BoardingReport_ShouldSetReportDataSourcesAndDefinitionFileCorrectly()
        {
            var report = new BoardingReport(_queries.Object, _fileSystem.Object);

            await report.ExecuteReport();

            AssertDataSourceContains(report, ReportDatasetName.Projects);
            AssertDataSourceContains(report, ReportDatasetName.Employees);
            Assert.Equal(ReportName.Boarding, report.ReportDefinitionFileName);
            Assert.NotNull(report.ReportViewer);
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
        public async Task ExecuteReport_AchAllCompaniesReport_ShouldSetReportDataSourceAndDefinitionFileCorrectly()
        {
            var report = new AchAllCompaniesReport(_queries.Object, _fileSystem.Object);

            await report.ExecuteReport();

            AssertDataSourceContains(report, ReportDatasetName.Master);
            Assert.Equal(ReportName.AchAllCompanies, report.ReportDefinitionFileName);
            Assert.NotNull(report.ReportViewer);
        }

        [Fact]
        public async Task ExecuteReport_CmcAddressByNameReport_ShouldSetReportDataSourceAndDefinitionFileCorrectly()
        {
            var report = new CmcAddressByNameReport(_queries.Object, _fileSystem.Object);

            await report.ExecuteReport();

            AssertDataSourceContains(report, ReportDatasetName.Master);
            Assert.Equal(ReportName.CmcAddressByName, report.ReportDefinitionFileName);
            Assert.NotNull(report.ReportViewer);
        }

        [Fact]
        public async Task ExecuteReport_CmcByIdUsefulInfoReport_ShouldSetReportDataSourceAndDefinitionFileCorrectly()
        {
            var report = new CmcByIdUsefulInfoReport(_queries.Object, _fileSystem.Object);

            await report.ExecuteReport();

            AssertDataSourceContains(report, ReportDatasetName.Master);
            Assert.Equal(ReportName.CmcByIdUsefulInfo, report.ReportDefinitionFileName);
            Assert.NotNull(report.ReportViewer);
        }

        private void AssertDataSourceContains(ReportBase report, string dataSourceName)
        {
            Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == dataSourceName);
        }
    }
}
