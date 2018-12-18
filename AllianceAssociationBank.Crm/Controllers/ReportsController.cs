using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Extensions;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using AllianceAssociationBank.Crm.ViewModels;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web;
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
        public ActionResult ViewReport(string reportName, int? projectId = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            if (!_reportSelector.IsReportExists(reportName))
            {
                throw new HttpNotFoundException($"A report with the name of {reportName} could not be found.");
            }

            var reportUrl = $"{Request.GetBaseUrl()}/{ReportViewerControlUrl}";

            reportUrl += $"?{QueryStringValue.ReportName}={reportName}";

            if (projectId.HasValue)
            {
                reportUrl += $"&{QueryStringValue.ProjectId}={projectId}";
            }

            if (startDate.HasValue && endDate.HasValue)
            {
                reportUrl += $"&{QueryStringValue.StartDate}={((DateTime)startDate).ToShortDateString()}";
                reportUrl += $"&{QueryStringValue.EndDate}={((DateTime)endDate).ToShortDateString()}";
            }

            ViewBag.ReportUrl = Uri.EscapeUriString(reportUrl);
            ViewBag.Title = reportName;

            return View(ReportsView.ViewReport);
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
    }
}