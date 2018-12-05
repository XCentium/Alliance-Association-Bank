using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using AllianceAssociationBank.Crm.ViewModels;
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
        //private IReportGenerationService _reportsService;

        private const string ReportViewerControlUrl = @"Infrastructure/ReportViewerControl.aspx";

        public ReportsController(IReportSelector reportSelector)
        {
            _reportSelector = reportSelector;
            //_reportsService = reportsService;
        }

        [Route("{name}/{projectId?}", Name = ReportsControllerRoute.ViewReport)]
        public async Task<ActionResult> ViewReport(string name, int? projectId = null)
        {
            var reportUrl = $"{ReportViewerControlUrl}?reportName={name}";
            if (projectId.HasValue)
            {
                reportUrl += $"&projectId={projectId}";
            }

            ViewBag.ReportUrl = Uri.EscapeUriString(reportUrl);
            ViewBag.Title = name;

            return View(ReportsView.ViewReport);


            //try
            //{
            //    IReport report;
            //    if (projectId.HasValue)
            //    {
            //        report = _reportSelector.ResolveByName(name, (int)projectId);
            //    }
            //    else
            //    {
            //        report = _reportSelector.ResolveByName(name);
            //    }

            //    await report.ExecuteReport();

            //    ViewBag.Title = name;
            //    var viewModel = new ReportViewModel()
            //    {
            //        GeneratedReport = report.ReportViewer
            //    };
            //    ViewBag.Title = name;
            //    //ViewBag.ReportViewer = report.ReportViewer;
            //    //ViewBag.Title = name;
            //    return View(ReportsView.ViewReport, viewModel);
            //}
            //catch (InvalidReportException e)
            //{
            //    throw new HttpNotFoundException(e);
            //}
        }
    }
}