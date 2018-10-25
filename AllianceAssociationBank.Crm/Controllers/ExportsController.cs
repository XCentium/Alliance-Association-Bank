using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    [RoutePrefix("Exports")]
    public class ExportsController : Controller
    {
        private IDataExportService _dataExportService;

        public ExportsController(IDataExportService dataExportService)
        {
            _dataExportService = dataExportService;
        }

        [Route("{name}", Name = ExportsControllerRoute.GenerateExportFile)]
        public async Task<ActionResult> GenerateExportFile(string name)
        {
            var exportFile = await _dataExportService.GenerateExportFileByName(name);

            if (exportFile == null)
            {
                throw new HttpNotFoundException();
            }

            return exportFile;
        }
    }
}