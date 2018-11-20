using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Reports;
using AllianceAssociationBank.Crm.Reports.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Reports
{
    public class ReportSelectorTests
    {
        private IReportSelector _reportSelector;

        private Mock<IReportQueries> _queries;
        private Mock<IFileSystemService> _fileSystem;

        public ReportSelectorTests()
        {
            _queries = new Mock<IReportQueries>();
            _fileSystem = new Mock<IFileSystemService>();

            _reportSelector = new ReportSelector();
        }

        [Theory]
        [InlineData(ReportName.Boarding, typeof(BoardingReport))]
        [InlineData(ReportName.CmcById, typeof(CmcByIdReport))]
        [InlineData(ReportName.CmcByName, typeof(CmcByNameReport))]
        [InlineData(ReportName.AchAllCompanies, typeof(AchAllCompaniesReport))]
        [InlineData(ReportName.CmcAddressByName, typeof(CmcAddressByNameReport))]
        [InlineData(ReportName.CmcByIdUsefulInfo, typeof(CmcByIdUsefulInfoReport))]
        public void ResolveByName_InlineReportWithNoParams_ShouldReturnCorrectReportInstance(string reportName, Type reportType)
        {
            _fileSystem.Setup(s => s.IsFileExists(It.IsAny<string>())).Returns(true);

            var report = _reportSelector.ResolveByName(reportName, _queries.Object, _fileSystem.Object);

            Assert.IsType(reportType, report);
        }

        [Theory]
        [InlineData(ReportName.AchSpec, typeof(AchSpecReport))]
        [InlineData(ReportName.AchInitialReview, typeof(AchInitialReviewReport))]
        [InlineData(ReportName.AchSixMonthReview, typeof(Ach6MonthReviewReport))]
        [InlineData(ReportName.AchRiskInitial, typeof(AchRiskInitialReport))]
        [InlineData(ReportName.AchRiskSixMonth, typeof(AchRisk6MonthReport))]
        [InlineData(ReportName.AchRiskPostSixMonth, typeof(AchRiskPost6MonthReport))]
        public void ResolveByName_InlineReportWithProjectIdParam_ShouldReturnCorrectReportInstance(string reportName, Type reportType)
        {
            _fileSystem.Setup(s => s.IsFileExists(It.IsAny<string>())).Returns(true);
            var projectId = 99;

            var report = _reportSelector.ResolveByName(reportName, projectId, _queries.Object, _fileSystem.Object);

            Assert.IsType(reportType, report);
        }

        [Fact]
        public void ResolveByName_InvalidReportName_ShouldThrowInvalidReportException()
        {
            var exception = Record.Exception(() => _reportSelector.ResolveByName("Some-Wrong-Report"));

            Assert.NotNull(exception);
            Assert.IsType<InvalidReportException>(exception);
        }
    }
}
