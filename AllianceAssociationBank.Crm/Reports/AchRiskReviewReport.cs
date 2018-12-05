using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class AchRiskReviewReport : ReportBase, IReport
    {
        private const string DefinitionFileName = ReportName.AchRiskReview;

        public AchRiskReviewReport() 
            : base(DefinitionFileName)
        {
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public AchRiskReviewReport(IReportQueries reportQueries, IFileSystemService fileSystemService)
            : base(reportQueries, fileSystemService, DefinitionFileName)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDataSetName.Master, 
                (await Queries.GetAchRiskReviewDataSetAsync())));
        }
    }
}