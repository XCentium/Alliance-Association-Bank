using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Core.Services;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Core.Services
{
    public class DataExportServiceTests
    {
        private IDataExportService _dataExport;
        private Mock<IReportQueries> _mockReportQueries;
        private List<Project> _projects;

        public DataExportServiceTests()
        {
            _mockReportQueries = new Mock<IReportQueries>();
            _dataExport = new DataExportService(_mockReportQueries.Object);

            _projects = new List<Project>()
            {
                new Project() { ID = 1, ProjectName = "Project 1" },
                new Project() { ID = 2, ProjectName = "Project 2" }
            };
        }

        [Fact]
        public async Task GenerateExportFileByName_CmcListExport_ShouldReturnFileStream()
        {
            var exportName = ExportName.CmcList;
            _mockReportQueries.Setup(q => q.GetCmcByIdDataSetAsync()).ReturnsAsync(_projects);

            var result = await _dataExport.GenerateExportFileByName(exportName);

            Assert.NotNull(result);
            Assert.Equal("text/csv", result.ContentType);
            Assert.Equal($"{exportName}.csv", result.FileDownloadName);
        }

        [Theory]
        [InlineData(ExportName.CmcUsefulInfoList)]
        [InlineData(ExportName.AllInfo)]
        public async Task GenerateExportFileByName_InlineDataExportName_ShouldReturnFileStream(string exportName)
        {
            var result = await _dataExport.GenerateExportFileByName(exportName);

            Assert.NotNull(result);
            Assert.Equal($"{exportName}.csv", result.FileDownloadName);
        }

    }
}
