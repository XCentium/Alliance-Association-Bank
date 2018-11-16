
using AllianceAssociationBank.Crm.Constants.Reports;
using Microsoft.Reporting.WebForms;
using System.Threading.Tasks;

namespace AllianceAssociationBank.Crm.Reports
{
    public class CmcAddressByNameReport : ReportBase, IReport
    {
        public CmcAddressByNameReport() : base(ReportName.CmcAddressByName)
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