using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Interfaces;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class AchRiskInitialReport : ReportBase, IReport
    {
        private const string definitionFileName = ReportName.AchRiskInitial;

        public int ProjectId { get; }

        public AchRiskInitialReport(int projectId) 
            : base(definitionFileName)
        {
            ProjectId = projectId;
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public AchRiskInitialReport(int projectId, IReportQueries reportQueries, IFileSystemService fileSystemService) 
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