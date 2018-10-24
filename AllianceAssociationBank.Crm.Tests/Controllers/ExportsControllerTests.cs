using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Tests.Helpers;
using Microsoft.Reporting.WebForms;
using Moq;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Controllers
{
    public class ExportsControllerTests
    {
        private ExportsController controller;

        private Mock<IDataExportService> dataExportServiceMock;

        private const string CSV_CONTENT_TYPE = "text/csv";

        public ExportsControllerTests()
        {
            dataExportServiceMock = new Mock<IDataExportService>();

            controller = new ExportsController(dataExportServiceMock.Object);
        }

        [Fact]
        public async Task GenerateExportFile_CmcListExport_ShouldReturnFileStreamResult()
        {
            var exportName = ExportName.CmcList;
            var fileStreamResult = new FileStreamResult(new MemoryStream(), CSV_CONTENT_TYPE);
            dataExportServiceMock.Setup(s => s.GenerateExportFileByName(exportName)).ReturnsAsync(fileStreamResult);

            var result = await controller.GenerateExportFile(exportName);

            var fileResult = Assert.IsType<FileStreamResult>(result);
            Assert.NotNull(fileResult);
        }

        [Fact]
        public async Task GenerateExportFile_InvalidExport_ShouldReturnViewErrorResult() //ShouldThrowHttpNotFoundException()
        {
            var exportName = "Wrong Export";
            dataExportServiceMock.Setup(s => s.GenerateExportFileByName(exportName)).ReturnsAsync(null as FileStreamResult);

            var result = await controller.GenerateExportFile(exportName);

            var errorViewResult = Assert.IsType<ViewErrorResult>(result);
            Assert.NotNull(errorViewResult);

            //var exception = await Record.ExceptionAsync(() => controller.GenerateExportFile(exportName));
            //Assert.NotNull(exception);
            //Assert.IsType<HttpNotFoundException>(exception);
        }
    }
}
