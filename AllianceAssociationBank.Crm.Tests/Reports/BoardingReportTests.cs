using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Reports
{
    public class BoardingReportTests
    {
        private BoardingReport _report;

        private Mock<IReportQueries> _queries;
        private Mock<IFileSystemService> _fileSystem;

        public BoardingReportTests()
        {
            _queries = new Mock<IReportQueries>();
            _fileSystem = new Mock<IFileSystemService>();
        }

        [Fact]
        public async Task ExecuteReport_ValidExecution_ShouldSetReportDataSources()
        {
            _fileSystem.Setup(s => s.IsFileExists(It.IsAny<string>())).Returns(true);
            _report = new BoardingReport(_queries.Object, _fileSystem.Object);

            await _report.ExecuteReport();

            Assert.Equal(2, _report.ReportViewer.LocalReport.DataSources.Count);
            Assert.NotNull(_report.ReportViewer);
        }
    }
}
