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

        [Route("{reportName}", Name = ReportsControllerRoute.ViewReport)]
        public ActionResult ViewReport(string reportName, DateTime? startDate = null, DateTime? endDate = null)
        {
            ThrowErrorOnInvalidReportName(reportName);

            var baseUrl = Request.GetBaseUrl();
            var reportUrl = $"{baseUrl}/{ReportViewerControlUrl}?{QueryStringValue.ReportName}={reportName}";

            if (startDate.HasValue && endDate.HasValue)
            {
                reportUrl += $"&{QueryStringValue.StartDate}={((DateTime)startDate).ToShortDateString()}";
                reportUrl += $"&{QueryStringValue.EndDate}={((DateTime)endDate).ToShortDateString()}";
            }

            return GetReportViewResult(reportName, reportUrl);
        }

        [Route("{reportName}/{projectId}", Name = ReportsControllerRoute.ViewReportForProject)]
        public ActionResult ViewReport(string reportName, int projectId)
        {
            ThrowErrorOnInvalidReportName(reportName);

            var baseUrl = Request.GetBaseUrl();
            var reportUrl = $"{baseUrl}/{ReportViewerControlUrl}?{QueryStringValue.ReportName}={reportName}";
            reportUrl += $"&{QueryStringValue.ProjectId}={projectId}";

            return GetReportViewResult(reportName, reportUrl);
        }

        [Route("{reportName}/Parameters", Name = ReportsControllerRoute.ParametersPrompt)]
        public ActionResult ParametersPrompt(string reportName)
        {
            var viewModel = new ReportParametersPromptViewModel()
            {
                ReportName = reportName,
                StartDate = new DateTime(DateTime.Today.Year, 1, 1),
                EndDate = new DateTime(DateTime.Today.Year, 12, 31)
            };

            return PartialView(ReportsView.DateParametersPromptPartial, viewModel);
        }

        private void ThrowErrorOnInvalidReportName(string reportName)
        {
            if (!_reportSelector.IsReportExists(reportName))
            {
                throw new HttpNotFoundException($"A report with the name of {reportName} could not be found.");
            }
        }

        private ActionResult GetReportViewResult(string reportName, string reportUrl)
        {
            ViewBag.ReportUrl = Uri.EscapeUriString(reportUrl);
            ViewBag.Title = reportName;

            return View(ReportsView.ViewReport);
        }
    }
}