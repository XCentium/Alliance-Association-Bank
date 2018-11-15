using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class BoardingReport : ReportBase, IReport
    {
        public BoardingReport() : base(ReportName.Boarding)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDatasetName.Projects, 
                (await Queries.GetBoardingDataSetAsync())));

            DataSources.Add(new ReportDataSource(
                ReportDatasetName.Employees, 
                (await Queries.GetEmployeesDataSetAsync())));
        }
    }
}