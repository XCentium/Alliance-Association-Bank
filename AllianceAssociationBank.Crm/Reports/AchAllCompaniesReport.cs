using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Interfaces;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class AchAllCompaniesReport : ReportBase, IReport
    {
        public AchAllCompaniesReport() 
            : base(ReportName.AchAllCompanies)
        {
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public AchAllCompaniesReport(IReportQueries reportQueries, IFileSystemService fileSystemService)
            : base(reportQueries, fileSystemService, ReportName.AchAllCompanies)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDatasetName.Master, 
                (await Queries.GetAchAllCompaniesDataSetAsync())));
        }
    }
}