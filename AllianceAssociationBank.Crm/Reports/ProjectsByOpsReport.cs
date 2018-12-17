using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class ProjectsByOpsReport : ReportBase, IReport
    {
        private const string definitionFileName = "Projects-By-Ops";

        public ProjectsByOpsReport() 
            : base(definitionFileName)
        {
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public ProjectsByOpsReport(IReportQueries reportQueries, IFileSystemService fileSystemService) 
            : base(reportQueries, fileSystemService, definitionFileName)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDataSetName.Projects, 
                (await Queries.GetBoardingDataSetAsync())));

            DataSources.Add(new ReportDataSource(
                ReportDataSetName.Employees, 
                (await Queries.GetEmployeesDataSetAsync())));
        }
    }
}