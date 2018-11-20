using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;
using System.Threading.Tasks;

namespace AllianceAssociationBank.Crm.Reports
{
    public class IncorrectEmployeesDataReport : ReportBase, IReport
    {
        private const string definitionFileName = ReportName.IncorrectEmployeesData;

        public IncorrectEmployeesDataReport() : base(definitionFileName)
        {
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public IncorrectEmployeesDataReport(IReportQueries reportQueries, IFileSystemService fileSystemService)
            : base(reportQueries, fileSystemService, definitionFileName)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDatasetName.Master,
                (await Queries.GetIncorrectEmployeesDataSetAsync())));
        }
    }
}