using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace AllianceAssociationBank.Crm.Reports.Infrastructure
{
    public partial class ReportViewerControl : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await GenerateReport();
            }
        }

        private async Task GenerateReport()
        {
            try
            {
                var reportName = Request["reportName"];
                var projectId = Request["projectId"];

                if (string.IsNullOrEmpty(reportName))
                {
                    throw new ArgumentNullException("reportName", "Value cannot be null.");
                }

                IReportSelector reportSelector = UnityConfig.Container.Resolve<IReportSelector>();
                IReport report;

                if (projectId != null && int.TryParse(projectId, out var projectIdParam))
                {
                    report = reportSelector.ResolveByName(reportName, projectIdParam);
                }
                else
                {
                    report = reportSelector.ResolveByName(reportName);
                }

                await report.ExecuteReport();

                // TODO: need a better solution here
                var reportDefinition = report.ReportViewer;
                ReportViewer1.ProcessingMode = reportDefinition.ProcessingMode;
                ReportViewer1.LocalReport.ReportPath = reportDefinition.LocalReport.ReportPath;
                ReportViewer1.AsyncRendering = reportDefinition.AsyncRendering;
                //ReportViewer1.SizeToReportContent = reportDefinition.SizeToReportContent;
                ReportViewer1.Width = Unit.Pixel(1278);
                ReportViewer1.Height = Unit.Pixel(679);
                ReportViewer1.WaitControlDisplayAfter = reportDefinition.WaitControlDisplayAfter;
                ReportViewer1.ShowBackButton = reportDefinition.ShowBackButton;
                foreach (var dataSource in reportDefinition.LocalReport.DataSources)
                {
                    ReportViewer1.LocalReport.DataSources.Add(dataSource);
                }
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                // TODO: need a solution here
                //throw new HttpNotFoundException(ex);
            }
        }    
    }
}