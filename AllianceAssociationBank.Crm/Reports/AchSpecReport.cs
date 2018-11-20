using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Interfaces;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class AchSpecReport : ReportBase, IReport
    {
        private const string definitionFileName = ReportName.AchSpec;

        public int ProjectId { get; }

        public AchSpecReport(int projectId) 
            : base(definitionFileName)
        {
            ProjectId = projectId;
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public AchSpecReport(int projectId, IReportQueries reportQueries, IFileSystemService fileSystemService) 
            : base(reportQueries, fileSystemService, definitionFileName)
        {
            ProjectId = projectId;
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDatasetName.AchReportDataset, 
                (await Queries.GetAchReportDataSetAsync(ProjectId))));
        }
    }
}