using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Interfaces;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class SoftwareTransitionReport : ReportBase, IReport
    {
        private const string definitionFileName = ReportName.SoftwareTransition;

        public SoftwareTransitionReport() 
            : base(definitionFileName)
        {
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public SoftwareTransitionReport(IReportQueries reportQueries, IFileSystemService fileSystemService) 
            : base(reportQueries, fileSystemService, definitionFileName)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDatasetName.Projects, 
                (await Queries.GetSoftwareTransitionDataSetAsync())));

            DataSources.Add(new ReportDataSource(
                ReportDatasetName.Employees, 
                (await Queries.GetEmployeesDataSetAsync())));
        }
    }
}