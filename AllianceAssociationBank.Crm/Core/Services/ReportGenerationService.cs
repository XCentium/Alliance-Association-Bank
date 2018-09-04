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

            switch (reportName.ToLower())
            {
                case ReportNames.Boarding:
                    {
                        dataSources.Add(new ReportDataSource("ProjectsDataset", (await _queries.GetBoardingDataSetAsync())));
                        dataSources.Add(new ReportDataSource("EmployeesDataset", (await _queries.GetEmployeesDataSetAsync())));
                        dataSources.Add(new ReportDataSource("SoftwareDataset", (await _queries.GetSoftwareDataSetAsync())));
                        break;
                    }
                case ReportNames.CompletedAndHold:
                    {
                        dataSources.Add(new ReportDataSource("ProjectsDataset", (await _queries.GetCompletedAndHoldDataSetAsync())));
                        dataSources.Add(new ReportDataSource("EmployeesDataset", (await _queries.GetEmployeesDataSetAsync())));
                        break;
                    }
                case ReportNames.SoftwareTransition:
                    {
                        dataSources.Add(new ReportDataSource("ProjectsDataset", (await _queries.GetSoftwareTransitionDataSetAsync())));
                        dataSources.Add(new ReportDataSource("EmployeesDataset", (await _queries.GetEmployeesDataSetAsync())));
                        dataSources.Add(new ReportDataSource("SoftwareDataset", (await _queries.GetSoftwareDataSetAsync())));
                        break;
                    }
            }

            return dataSources;
        }
    }
}