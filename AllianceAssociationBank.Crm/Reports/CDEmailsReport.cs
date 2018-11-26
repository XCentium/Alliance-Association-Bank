using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class CDEmailsReport : ReportBase, IReport
    {
        private const string definitionFileName = ReportName.CDEmails;

        public CDEmailsReport() 
            : base(definitionFileName)
        {
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public CDEmailsReport(IReportQueries reportQueries, IFileSystemService fileSystemService) 
            : base(reportQueries, fileSystemService, definitionFileName)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDataSetName.Master, 
                (await Queries.GetCDEmailsDataSetAsync())));
        }
    }
}