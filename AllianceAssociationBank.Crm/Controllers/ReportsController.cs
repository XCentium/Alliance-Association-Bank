using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Extensions;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using AllianceAssociationBank.Crm.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.SessionState;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    [RoutePrefix("Reports")]
    public class ReportsController : Controller
    {
        private IReportSelector _reportSelector;

        private const string ReportViewerControlUrl = @"Reports/Infrastructure/ReportViewerControl.aspx";

        public ReportsController(IReportSelector reportSelector)
        {
            _reportSelector = reportSelector;
        }

        [Route("{name}/{projectId?}", Name = ReportsControllerRoute.ViewReport)]
        public ActionResult ViewReport(string name, int? projectId = null)
        {
            if (!_reportSelector.IsReportExists(name))
            {
                throw new HttpNotFoundException($"A report with the name of {name} could not be found.");
            }

            var baseUrl = Request.GetBaseUrl();
            var reportUrl = $"{baseUrl}/{ReportViewerControlUrl}?{QueryStringValue.ReportName}={name}";
            if (projectId.HasValue)
            {
                reportUrl += $"&{QueryStringValue.ProjectId}={projectId}";
            }

            ViewBag.ReportUrl = Uri.EscapeUriString(reportUrl);
            ViewBag.Title = name;

            return View(ReportsView.ViewReport);
        }

        [Route("Parameters/{report}", Name = "ReportParameters")]
        public ActionResult ParametersPrompt(string report)
        {
            var viewModel = new ReportParametersPromptViewModel()
            {
                ReportName = report,
                StartDate = new DateTime(DateTime.Today.Year, 1, 1),
                EndDate = new DateTime(DateTime.Today.Year, 12, 31),
            };
            return PartialView(ReportsView.DateParamsPromptPartial, viewModel);
        }
    }
}