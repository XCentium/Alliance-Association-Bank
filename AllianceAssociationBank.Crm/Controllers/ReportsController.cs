using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    [RoutePrefix("Reports")]
    public class ReportsController : Controller
    {
        private IReportGenerationService _reportsService;
        //private static readonly object reportViewerLock = new object();

        public ReportsController(IReportGenerationService reportsService)
        {
            _reportsService = reportsService;
        }

        [Route("{name}/{projectId?}", Name = ReportsControllerRoute.ViewReport)]
        public async Task<ActionResult> ViewReport(string name, int? projectId = null)
        {
            var reportViewer = await _reportsService.GenerateReportByName(name, projectId);

            if (reportViewer == null)
            {
                throw new HttpNotFoundException();
                //return new ViewErrorResult(HttpStatusCode.NotFound, httpRequest: HttpContext.Request);
            }

            ViewBag.ReportViewer = reportViewer;
            ViewBag.Title = name;

            return View(ReportsView.ViewReport);
        }
    }
}