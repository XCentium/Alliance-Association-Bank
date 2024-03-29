﻿using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Extensions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using Unity;

namespace AllianceAssociationBank.Crm.Reports.Infrastructure
{
    public partial class ReportViewerControl : System.Web.UI.Page
    {
        private string[] _availableReportParameters = new string[]
        {
            QueryStringValue.ProjectId,
            QueryStringValue.StartDate,
            QueryStringValue.EndDate
        };

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Page.User.Identity.IsAuthenticated)
            {
                await GenerateReport();
            }
        }

        private async Task GenerateReport()
        {
            var reportName = string.Empty;

            try
            {
                var reportService = UnityConfig.Container.Resolve<IReportService>();

                reportName = reportService.GetReportNameFromQueryString(Request.QueryString);
                var reportParameters = reportService.GetReportParametersFromQueryString(Request.QueryString, _availableReportParameters);
                var report = await reportService.GenerateReportByName(reportName, reportParameters);

                ReportViewer1.SetProperties(report.ReportViewer);
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                var logger = UnityConfig.Container.Resolve<ILogger>();
                logger.Error(ex, $"An exception occured while generating {reportName} report.");
                RedirectToErrorPage();
            }
        }
        
        private void RedirectToErrorPage()
        {
            // Redirect parent browser window to error page
            var baseUrl = Request.GetBaseUrl();
            var redirectUrl = $"{baseUrl}/Error/InternalError?aspxerrorpath=" + Uri.EscapeUriString(Request.Url.ToString());
            var script = $"window.top.location.href='{redirectUrl}';";

            ScriptManager.RegisterStartupScript(Page, GetType(), "parentWindowRedirect", script, true);
        }
    }
}