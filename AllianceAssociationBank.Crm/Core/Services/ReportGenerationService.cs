using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Core.Interfaces;
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
        private IReportQueries _queries;
        private const string REPORTS_DIRECTORY = "Reports";

        public ReportGenerationService(IReportQueries queries)
        {
            _queries = queries;
        }

        public async Task<ReportViewer> GenerateReportByName(string reportName)
        {
            var reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.AsyncRendering = true;
            reportViewer.SizeToReportContent = true;

            var reportPath = 
                HttpContext.Current.Request.MapPath(HttpContext.Current.Request.ApplicationPath) + $"{REPORTS_DIRECTORY}\\{reportName}.rdlc";

            if (System.IO.File.Exists(reportPath))
            {
                reportViewer.LocalReport.ReportPath = reportPath;

                foreach (var dataSource in (await GetDataSourcesByReportName(reportName)))
                {
                    reportViewer.LocalReport.DataSources.Add(dataSource);
                }
            }

            return reportViewer;
        }

        private async Task<IEnumerable<ReportDataSource>> GetDataSourcesByReportName(string reportName)
        {
            var dataSources = new Collection<ReportDataSource>();

            switch (reportName)
            {
                case var name when name.Equals(ReportNames.Boarding, StringComparison.InvariantCultureIgnoreCase):
                    {
                        dataSources.Add(new ReportDataSource(ReportDatasetNames.Projects, (await _queries.GetBoardingDataSetAsync())));
                        dataSources.Add(new ReportDataSource(ReportDatasetNames.Employees, (await _queries.GetEmployeesDataSetAsync())));
                        dataSources.Add(new ReportDataSource(ReportDatasetNames.Software, (await _queries.GetSoftwareDataSetAsync())));
                        break;
                    }
                case var name when name.Equals(ReportNames.CompletedAndHold, StringComparison.InvariantCultureIgnoreCase):
                    {
                        dataSources.Add(new ReportDataSource(ReportDatasetNames.Projects, (await _queries.GetCompletedAndHoldDataSetAsync())));
                        dataSources.Add(new ReportDataSource(ReportDatasetNames.Employees, (await _queries.GetEmployeesDataSetAsync())));
                        break;
                    }
                case var name when name.Equals(ReportNames.SoftwareTransition, StringComparison.InvariantCultureIgnoreCase):
                    {
                        dataSources.Add(new ReportDataSource(ReportDatasetNames.Projects, (await _queries.GetSoftwareTransitionDataSetAsync())));
                        dataSources.Add(new ReportDataSource(ReportDatasetNames.Employees, (await _queries.GetEmployeesDataSetAsync())));
                        dataSources.Add(new ReportDataSource(ReportDatasetNames.Software, (await _queries.GetSoftwareDataSetAsync())));
                        break;
                    }
            }

            return dataSources;
        }
    }
}