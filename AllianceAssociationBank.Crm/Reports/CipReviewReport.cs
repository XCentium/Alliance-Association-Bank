using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;
using System.Threading.Tasks;

namespace AllianceAssociationBank.Crm.Reports
{
    public class CipReviewReport : ReportBase, IReport
    {
        private const string DefinitionFileName = ReportName.CipReview;

        public CipReviewReport() : base(DefinitionFileName)
        {
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public CipReviewReport(IReportQueries reportQueries, IFileSystemService fileSystemService)
            : base(reportQueries, fileSystemService, DefinitionFileName)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDataSetName.Master,
                (await Queries.GetCipReviewDataSetAsync())));
        }
    }
}