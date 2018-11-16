using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Reports.Interfaces;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class AchAllCompaniesReport : ReportBase, IReport
    {
        public AchAllCompaniesReport() : base(ReportName.AchAllCompanies)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDatasetName.Master, 
                (await Queries.GetAchAllCompaniesDataSetAsync())));
        }
    }
}