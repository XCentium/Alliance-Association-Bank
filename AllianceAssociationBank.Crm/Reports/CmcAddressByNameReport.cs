using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;
using System.Threading.Tasks;

namespace AllianceAssociationBank.Crm.Reports
{
    // TODO: this report will not be used
    public class CmcAddressByNameReport : ReportBase, IReport
    {
        private const string definitionFileName = ReportName.CmcAddressByName;

        public CmcAddressByNameReport() 
            : base(definitionFileName)
        {
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public CmcAddressByNameReport(IReportQueries reportQueries, IFileSystemService fileSystemService)
            : base(reportQueries, fileSystemService, definitionFileName)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDataSetName.Master,
                (await Queries.GetCmcByNameDataSetAsync())));
        }
    }
}