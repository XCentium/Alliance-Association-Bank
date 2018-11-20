using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class CompletedAndHoldReport : ReportBase, IReport
    {
        private const string definitionFileName = ReportName.CompletedAndHold;

        public CompletedAndHoldReport() 
            : base(definitionFileName)
        {
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public CompletedAndHoldReport(IReportQueries reportQueries, IFileSystemService fileSystemService) 
            : base(reportQueries, fileSystemService, definitionFileName)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDatasetName.Projects, 
                (await Queries.GetCompletedAndHoldDataSetAsync())));

            DataSources.Add(new ReportDataSource(
                ReportDatasetName.Employees, 
                (await Queries.GetEmployeesDataSetAsync())));
        }
    }
}