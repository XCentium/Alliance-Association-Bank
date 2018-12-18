using System;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class ProjectsByOpsReport : ReportBase, IReport
    {
        private const string definitionFileName = ReportName.ProjectsByOps;

        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public ProjectsByOpsReport(DateTime startDate, DateTime endDate) 
            : base(definitionFileName)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public ProjectsByOpsReport(DateTime startDate, DateTime endDate, IReportQueries reportQueries, IFileSystemService fileSystemService)
            : base(reportQueries, fileSystemService, definitionFileName)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public async Task ExecuteReport()
        {
            ReportViewer.LocalReport.SetParameters(
                new ReportParameter(ReportParameterName.StartDate, StartDate.ToShortDateString()));
            ReportViewer.LocalReport.SetParameters(
                new ReportParameter(ReportParameterName.EndDate, EndDate.ToShortDateString()));

            DataSources.Add(new ReportDataSource(
                ReportDataSetName.Master, 
                await Queries.GetProjectsByOpsDataSetAsync(StartDate, EndDate)));

            DataSources.Add(new ReportDataSource(
                ReportDataSetName.Employees, 
                await Queries.GetEmployeesDataSetAsync()));
        }
    }
}