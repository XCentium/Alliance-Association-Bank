using AllianceAssociationBank.Crm.Persistence.Queries;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace AllianceAssociationBank.Crm.Core.Services
{
    public class ReportGenerationService
    {
        private ReportQueries _queries;

        public ReportGenerationService(ReportQueries queries)
        {
            _queries = queries;
        }

        public async Task<ReportViewer> GenerateByName(string reportName)
        {
            /*if (string.IsNullOrEmpty(reportName))
            {
                return null;
            }*/

            var reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.AsyncRendering = false;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(100);
            reportViewer.Height = Unit.Percentage(100);

            var reportMainDataSet = new ReportDataSource("ProjectsDataset", (await _queries.GetBoardingReportDataSetAsync()));
            var employeesDataSet = new ReportDataSource("EmployeesDataset", (await _queries.GetEmployeesDataSetAsync()));
            var softwareDataSet = new ReportDataSource("SoftwareDataset", (await _queries.GetSoftwareDataSetAsync()));

            reportViewer.LocalReport.DataSources.Add(reportMainDataSet);
            reportViewer.LocalReport.DataSources.Add(employeesDataSet);
            reportViewer.LocalReport.DataSources.Add(softwareDataSet);

            //TODO: check if report file exists
            reportViewer.LocalReport.ReportPath = 
                HttpContext.Current.Request.MapPath(HttpContext.Current.Request.ApplicationPath) + $"Reports\\{reportName}.rdlc";

            return reportViewer;
        }
    }
}