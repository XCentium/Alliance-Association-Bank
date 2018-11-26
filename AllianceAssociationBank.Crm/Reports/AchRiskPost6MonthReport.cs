using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class AchRiskPost6MonthReport : ReportBase, IReport
    {
        private const string definitionFileName = ReportName.AchRiskPostSixMonth;

        public int ProjectId { get; }

        public AchRiskPost6MonthReport(int projectId) 
            : base(definitionFileName)
        {
            ProjectId = projectId;
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public AchRiskPost6MonthReport(int projectId, IReportQueries reportQueries, IFileSystemService fileSystemService) 
            : base(reportQueries, fileSystemService, definitionFileName)
        {
            ProjectId = projectId;
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDataSetName.Master, 
                (await Queries.GetAchReportDataSetAsync(ProjectId))));
        }
    }
}