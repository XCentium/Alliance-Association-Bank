
using AllianceAssociationBank.Crm.Constants.Reports;
using Microsoft.Reporting.WebForms;
using System.Threading.Tasks;

namespace AllianceAssociationBank.Crm.Reports
{
    public class CmcByIdUsefulInfoReport : ReportBase, IReport
    {
        public CmcByIdUsefulInfoReport() : base(ReportName.CmcByIdUsefulInfo)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDatasetName.Master,
                (await Queries.GetCmcByIdDataSetAsync())));
        }
    }
}