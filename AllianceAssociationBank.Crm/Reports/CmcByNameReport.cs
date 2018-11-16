using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Reports.Interfaces;
using Microsoft.Reporting.WebForms;
using System.Threading.Tasks;

namespace AllianceAssociationBank.Crm.Reports
{
    public class CmcByNameReport : ReportBase, IReport
    {
        public CmcByNameReport() : base(ReportName.CmcByName)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDatasetName.Master,
                (await Queries.GetCmcByNameDataSetAsync())));
        }
    }
}