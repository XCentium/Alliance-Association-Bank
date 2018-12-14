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
        [InlineData(typeof(CmcByIdReport), ReportDataSetName.Master)]
        [InlineData(typeof(CmcByNameReport), ReportDataSetName.Master)]
        [InlineData(typeof(CDEmailsReport), ReportDataSetName.Master)]
        [InlineData(typeof(AchRiskReviewReport), ReportDataSetName.Master)]
        [InlineData(typeof(CmcByIdUsefulInfoReport), ReportDataSetName.Master)]
        [InlineData(typeof(CipReviewReport), ReportDataSetName.Master)]
        [InlineData(typeof(IncorrectEmployeeDataReport), ReportDataSetName.Master)]
        public async Task ExecuteReport_InlineReportWithNoParams_ShouldSetReportDataSourceCorrectly(Type reportType, 
                                                                                                    string dataSourceName)
        {
            var report = CreateReportInstance(reportType);

            await report.ExecuteReport();

            Assert.Contains(report.ReportViewer.LocalReport.DataSources, d => d.Name == dataSourceName);
            Assert.NotNull(report.ReportViewer);
        }

        [Theory]
        [InlineData(typeof(AchSpecReport), ReportDataSetName.Master)]
        [InlineData(typeof(AchInitialReviewReport), ReportDataSetName.Master)]
        [InlineData(typeof(Ach6MonthReviewReport), ReportDataSetName.Master)]
        [InlineData(typeof(AchRiskInitialReport), ReportDataSetName.Master)]
        [InlineData(typeof(AchRisk6MonthReport), ReportDataSetName.Master)]
        [InlineData(typeof(AchRiskPost6MonthReport), ReportDataSetName.Master)]
        [InlineData(typeof(WelcomeChecklistReport), ReportDataSetName.Master)]
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
        [InlineData(typeof(BoardingReport), ReportDataSetName.Projects, ReportDataSetName.Employees)]
        [InlineData(typeof(CompletedAndHoldReport), ReportDataSetName.Projects, ReportDataSetName.Employees)]
        [InlineData(typeof(SoftwareTransitionReport), ReportDataSetName.Projects, ReportDataSetName.Employees)]
        [InlineData(typeof(CouponReport), ReportDataSetName.Projects, ReportDataSetName.Employees)]
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
        [InlineData(typeof(AchRiskReviewReport), ReportName.AchRiskReview)]
        [InlineData(typeof(CmcByIdUsefulInfoReport), ReportName.CmcByIdUsefulInfo)]
        [InlineData(typeof(CipReviewReport), ReportName.CipReview)]
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
        [InlineData(typeof(WelcomeChecklistReport), ReportName.WelcomeChecklist)]
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
