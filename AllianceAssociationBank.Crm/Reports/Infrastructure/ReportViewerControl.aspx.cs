using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web.UI;
using Unity;

namespace AllianceAssociationBank.Crm.Reports.Infrastructure
{
    public partial class ReportViewerControl : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Page.User.Identity.IsAuthenticated)
            {
                await GenerateReport();
            }
        }

        private async Task GenerateReport()
        {
            try
            {
                var reportName = Request[QueryStringValue.ReportName];
                var projectId = Request[QueryStringValue.ProjectId];

                var reportService = UnityConfig.Container.Resolve<IReportService>();

                var parameters = new Dictionary<string, object>();
                if (!string.IsNullOrEmpty(projectId))
                {
                    parameters.Add(ReportParameterName.ProjectId, projectId);
                }

                var report = await reportService.GenerateReportByName(reportName, parameters);

                ReportViewer1.SetProperties(report.ReportViewer);

                //PermissionSet permissions = new PermissionSet(PermissionState.Unrestricted);
                //permissions.AddPermission(new FileIOPermission(PermissionState.Unrestricted));
                //permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.AllFlags));
                //ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(permissions);

                //Assembly asm = Assembly.Load("AllianceAssociationBank.Crm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
                //AssemblyName asm_name = asm.GetName();
                //ReportViewer1.LocalReport.AddFullTrustModuleInSandboxAppDomain(new StrongName(new StrongNamePublicKeyBlob(asm_name.GetPublicKey()), asm_name.Name, asm_name.Version));

                //ReportViewer1.LocalReport.Refresh();
                //ReportViewer1.LocalReport.ReleaseSandboxAppDomain();
            }
            catch (Exception )
            {
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