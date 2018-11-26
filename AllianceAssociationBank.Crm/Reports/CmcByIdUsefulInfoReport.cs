using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace AllianceAssociationBank.Crm.Reports
{
    // TODO: also need to fit in scanner info here
    public class CmcByIdUsefulInfoReport : ReportBase, IReport
    {
        private const string DefinitionFileName = ReportName.CmcByIdUsefulInfo;
        private const int ReportViewerWidthPixels = 1278;

        public CmcByIdUsefulInfoReport() 
            : base(DefinitionFileName)
        {
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public CmcByIdUsefulInfoReport(IReportQueries reportQueries, IFileSystemService fileSystemService)
            : base(reportQueries, fileSystemService, DefinitionFileName)
        {
        }

        public async Task ExecuteReport()
        {
            // override default width and height
            ReportViewer.SizeToReportContent = false;
            ReportViewer.Width = Unit.Pixel(ReportViewerWidthPixels);
            ReportViewer.Height = Unit.Percentage(100);

            DataSources.Add(new ReportDataSource(
                ReportDataSetName.Master,
                (await Queries.GetCmcByIdDataSetAsync())));
        }
    }
}