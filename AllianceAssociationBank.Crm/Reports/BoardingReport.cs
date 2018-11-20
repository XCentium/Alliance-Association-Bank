using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class BoardingReport : ReportBase, IReport
    {
        private const string definitionFileName = ReportName.Boarding;

        public BoardingReport() 
            : base(definitionFileName)
        {
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public BoardingReport(IReportQueries reportQueries, IFileSystemService fileSystemService) 
            : base(reportQueries, fileSystemService, definitionFileName)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDatasetName.Projects, 
                (await Queries.GetBoardingDataSetAsync())));

            DataSources.Add(new ReportDataSource(
                ReportDatasetName.Employees, 
                (await Queries.GetEmployeesDataSetAsync())));
        }
    }
}