using AllianceAssociationBank.Crm.Persistence.Queries;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public async Task<ReportViewer> GenerateReportByName(string reportName)
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

            foreach (var dataSource in (await GetDataSourcesByReportName(reportName)))
            {
                reportViewer.LocalReport.DataSources.Add(dataSource);
            }

            //TODO: check if report file exists
            reportViewer.LocalReport.ReportPath = 
                HttpContext.Current.Request.MapPath(HttpContext.Current.Request.ApplicationPath) + $"Reports\\{reportName}.rdlc";

            return reportViewer;
        }

        private async Task<IEnumerable<ReportDataSource>> GetDataSourcesByReportName(string reportName)
        {
            var dataSources = new Collection<ReportDataSource>();

            switch (reportName)
            {
                case "BoardingReport":
                case "SoftwareTransitionReport":
                {
                    dataSources.Add(new ReportDataSource("ProjectsDataset", (await _queries.GetBoardingReportDataSetAsync())));
                    dataSources.Add(new ReportDataSource("EmployeesDataset", (await _queries.GetEmployeesDataSetAsync())));
                    dataSources.Add(new ReportDataSource("SoftwareDataset", (await _queries.GetSoftwareDataSetAsync())));
                    break;
                }
            }

            return dataSources;
        }
    }
}