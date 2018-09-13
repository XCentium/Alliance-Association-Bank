using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
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
            try
            {
                var exportFile = await _dataExportService.GenerateExportFileByName(name);

                if (exportFile == null)
                {
                    return HttpNotFound();
                }

                return exportFile;
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}