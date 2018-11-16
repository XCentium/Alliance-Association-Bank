using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Reports;
using AllianceAssociationBank.Crm.Reports.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    [RoutePrefix("Reports")]
    public class ReportsController : Controller
    {
        private IReportSelector _reportSelector;
        private IReportGenerationService _reportsService;

        //private static readonly object reportViewerLock = new object();

        public ReportsController(IReportSelector reportSelector, IReportGenerationService reportsService)
        {
            _reportSelector = reportSelector;
            _reportsService = reportsService;
        }

        [Route("{name}/{projectId?}", Name = ReportsControllerRoute.ViewReport)]
        public async Task<ActionResult> ViewReport(string name, int? projectId = null)
        {
            try
            {
                IReport report;
                if (projectId.HasValue)
                {
                    report = _reportSelector.ResolveByName(name, (int)projectId);
                }
                else
                {
                    report = _reportSelector.ResolveByName(name);
                }

                await report.ExecuteReport();

                ViewBag.ReportViewer = report.ReportViewer;
                ViewBag.Title = name;
                return View(ReportsView.ViewReport);
            }
            catch (Exception e)
            {
                throw new HttpNotFoundException(e);
            }

            //var reportViewer = await _reportsService.GenerateReportByName(name, projectId);
            //if (reportViewer == null)
            //{
            //    throw new HttpNotFoundException();
            //}
            //ViewBag.ReportViewer = reportViewer;
            //ViewBag.Title = name;
            //return View(ReportsView.ViewReport);
        }
    }
}