using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class WelcomeChecklistReport : ReportBase, IReport
    {
        public const string DefinitionFileName = ReportName.WelcomeChecklist;

        public int ProjectId { get; }

        public WelcomeChecklistReport(int projectId) 
            : base(DefinitionFileName)
        {
            ProjectId = projectId;
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public WelcomeChecklistReport(int projectId, IReportQueries reportQueries, IFileSystemService fileSystemService)
            : base(reportQueries, fileSystemService, DefinitionFileName)
        {
            ProjectId = projectId;
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDataSetName.Master,
                await Queries.GetWelcomeChecklistDataSetAsync(ProjectId)));
        }
    }
}