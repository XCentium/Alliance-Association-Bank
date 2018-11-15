using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AllianceAssociationBank.Crm.Constants.Reports;
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
                ReportDatasetName.AchReportDataset, 
                (await Queries.GetAchAllCompaniesDataSetAsync())));
        }
    }
}