using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;
using System.Threading.Tasks;

namespace AllianceAssociationBank.Crm.Reports
{
    public class CmcByIdReport : ReportBase, IReport
    {
        private const string definitionFileName = ReportName.CmcById;

        public CmcByIdReport() : base(definitionFileName)
        {
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public CmcByIdReport(IReportQueries reportQueries, IFileSystemService fileSystemService)
            : base(reportQueries, fileSystemService, definitionFileName)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDataSetName.Master,
                (await Queries.GetCmcByIdDataSetAsync())));
        }
    }
}