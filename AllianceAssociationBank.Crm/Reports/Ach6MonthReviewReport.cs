using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class Ach6MonthReviewReport : ReportBase, IReport
    {
        private const string definitionFileName = ReportName.AchSixMonthReview;

        public int ProjectId { get; }

        public Ach6MonthReviewReport(int projectId) 
            : base(definitionFileName)
        {
            ProjectId = projectId;
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public Ach6MonthReviewReport(int projectId, IReportQueries reportQueries, IFileSystemService fileSystemService) 
            : base(reportQueries, fileSystemService, definitionFileName)
        {
            ProjectId = projectId;
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDatasetName.Master, 
                (await Queries.GetAchReportDataSetAsync(ProjectId))));
        }
    }
}