using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Reports;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Moq;
using System;
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
        [InlineData(typeof(CDEmailsReport), ReportDatasetName.Master)]
        [InlineData(typeof(AchAllCompaniesReport), ReportDatasetName.Master)]
        [InlineData(typeof(CmcAddressByNameReport), ReportDatasetName.Master)]
        [InlineData(typeof(CmcByIdUsefulInfoReport), ReportDatasetName.Master)]
        [InlineData(typeof(IncorrectEmployeeDataReport), ReportDatasetName.Master)]
        public async Task ExecuteReport_InlineReportWithNoParams_ShouldSetReportDataSourceCorrectly(Type reportType, 
                                                                                                    string dataSourceName)
        {
            var report = CreateReportInstance(reportType);

            await report.ExecuteReport();

            Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == dataSourceName);
            Assert.NotNull(report.ReportViewer);
        }

        [Theory]
        [InlineData(typeof(AchSpecReport), ReportDatasetName.Master)]
        [InlineData(typeof(AchInitialReviewReport), ReportDatasetName.Master)]
        [InlineData(typeof(Ach6MonthReviewReport), ReportDatasetName.Master)]
        [InlineData(typeof(AchRiskInitialReport), ReportDatasetName.Master)]
        [InlineData(typeof(AchRisk6MonthReport), ReportDatasetName.Master)]
        [InlineData(typeof(AchRiskPost6MonthReport), ReportDatasetName.Master)]
        public async Task ExecuteReport_InlineReportWithProjectIdParam_ShouldSetReportDataSourceCorrectly(Type reportType, 
                                                                                                          string dataSourceName)
        {
            var projectId = 99;
            var report = CreateReportInstance(reportType, projectId);

            await report.ExecuteReport();

            Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == dataSourceName);
            Assert.NotNull(report.ReportViewer);
        }

        [Theory]
        [InlineData(typeof(BoardingReport), ReportDatasetName.Projects, ReportDatasetName.Employees)]
        [InlineData(typeof(CompletedAndHoldReport), ReportDatasetName.Projects, ReportDatasetName.Employees)]
        [InlineData(typeof(SoftwareTransitionReport), ReportDatasetName.Projects, ReportDatasetName.Employees)]
        [InlineData(typeof(CouponReport), ReportDatasetName.Projects, ReportDatasetName.Employees)]
        public async Task ExecuteReport_InlineReportWithNoParams_ShouldSetTwoReportDataSourcesCorrectly(Type reportType, 
                                                                                                        string dataSourceNameOne, 
                                                                                                        string dataSourceNameTwo)
        {
            var report = CreateReportInstance(reportType);

            await report.ExecuteReport();

            Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == dataSourceNameOne);
            Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == dataSourceNameTwo);
            Assert.NotNull(report.ReportViewer);
        }

        [Theory]
        [InlineData(typeof(BoardingReport), ReportName.Boarding)]
        [InlineData(typeof(CompletedAndHoldReport), ReportName.CompletedAndHold)]
        [InlineData(typeof(SoftwareTransitionReport), ReportName.SoftwareTransition)]
        [InlineData(typeof(CmcByIdReport), ReportName.CmcById)]
        [InlineData(typeof(CmcByNameReport), ReportName.CmcByName)]
        [InlineData(typeof(CDEmailsReport), ReportName.CDEmails)]
        [InlineData(typeof(CouponReport), ReportName.Coupon)]
        [InlineData(typeof(AchAllCompaniesReport), ReportName.AchAllCompanies)]
        [InlineData(typeof(CmcAddressByNameReport), ReportName.CmcAddressByName)]
        [InlineData(typeof(CmcByIdUsefulInfoReport), ReportName.CmcByIdUsefulInfo)]
        [InlineData(typeof(IncorrectEmployeeDataReport), ReportName.IncorrectEmployeeData)]
        public async Task ExecuteReport_InlineReportWithNoParams_ShouldSetDefinitionFileNameCorrectly(Type reportType, 
                                                                                                      string definitionFileName)
        {
            var report = CreateReportInstance(reportType);

            await report.ExecuteReport();

            var reportBase = Assert.IsAssignableFrom<ReportBase>(report);
            Assert.Equal(definitionFileName, reportBase.ReportDefinitionFileName);
        }

        [Theory]
        [InlineData(typeof(AchSpecReport), ReportName.AchSpec)]
        [InlineData(typeof(AchInitialReviewReport), ReportName.AchInitialReview)]
        [InlineData(typeof(Ach6MonthReviewReport), ReportName.AchSixMonthReview)]
        [InlineData(typeof(AchRiskInitialReport), ReportName.AchRiskInitial)]
        [InlineData(typeof(AchRisk6MonthReport), ReportName.AchRiskSixMonth)]
        [InlineData(typeof(AchRiskPost6MonthReport), ReportName.AchRiskPostSixMonth)]
        public async Task ExecuteReport_InlineReportWithProjectIdParam_ShouldSetDefinitionFileNameCorrectly(Type reportType, 
                                                                                                            string definitionFileName)
        {
            var projectId = 99;
            var report = CreateReportInstance(reportType, projectId);

            await report.ExecuteReport();

            var reportBase = Assert.IsAssignableFrom<ReportBase>(report);
            Assert.Equal(definitionFileName, reportBase.ReportDefinitionFileName);
        }

        [Fact]
        public void Constructor_BoardingReportWithInvalidDefinitionFile_ShouldThrowInvalidReportException()
        {
            _fileSystem.Setup(s => s.IsFileExists(It.IsAny<string>())).Returns(false);

            var exception = Record.Exception(() => new BoardingReport(_queries.Object, _fileSystem.Object));

            Assert.NotNull(exception);
            Assert.IsType<InvalidReportException>(exception);
        }

        //[Fact]
        //public async Task ExecuteReport_BoardingReport_ShouldSetReportDataSourcesCorrectly()
        //{
        //    var report = new BoardingReport(_queries.Object, _fileSystem.Object);

        //    await report.ExecuteReport();

        //    Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == ReportDatasetName.Projects);
        //    Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == ReportDatasetName.Employees);
        //    Assert.NotNull(report.ReportViewer);
        //}

        //[Fact]
        //public async Task ExecuteReport_CompletedAndHoldReport_ShouldSetReportDataSourcesCorrectly()
        //{
        //    var report = new CompletedAndHoldReport(_queries.Object, _fileSystem.Object);

        //    await report.ExecuteReport();

        //    Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == ReportDatasetName.Projects);
        //    Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == ReportDatasetName.Employees);
        //    Assert.NotNull(report.ReportViewer);
        //}

        //[Fact]
        //public async Task ExecuteReport_SoftwareTransitionReport_ShouldSetReportDataSourcesCorrectly()
        //{
        //    var report = new SoftwareTransitionReport(_queries.Object, _fileSystem.Object);

        //    await report.ExecuteReport();

        //    Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == ReportDatasetName.Projects);
        //    Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == ReportDatasetName.Employees);
        //    Assert.NotNull(report.ReportViewer);
        //}

        //[Fact]
        //public async Task ExecuteReport_CouponReport_ShouldSetReportDataSourcesCorrectly()
        //{
        //    var report = new CouponReport(_queries.Object, _fileSystem.Object);

        //    await report.ExecuteReport();

        //    Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == ReportDatasetName.Projects);
        //    Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == ReportDatasetName.Employees);
        //    Assert.NotNull(report.ReportViewer);
        //}

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
