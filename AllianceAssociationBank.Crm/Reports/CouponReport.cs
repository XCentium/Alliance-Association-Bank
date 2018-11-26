using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Reports.Infrastructure;
using Microsoft.Reporting.WebForms;

namespace AllianceAssociationBank.Crm.Reports
{
    public class CouponReport : ReportBase, IReport
    {
        private const string definitionFileName = ReportName.Coupon;

        public CouponReport() 
            : base(definitionFileName)
        {
        }

        /// <summary>
        /// This constructor is used for unit testing.
        /// </summary>
        public CouponReport(IReportQueries reportQueries, IFileSystemService fileSystemService) 
            : base(reportQueries, fileSystemService, definitionFileName)
        {
        }

        public async Task ExecuteReport()
        {
            DataSources.Add(new ReportDataSource(
                ReportDataSetName.Projects, 
                (await Queries.GetCouponDataSetAsync())));

            DataSources.Add(new ReportDataSource(
                ReportDataSetName.Employees, 
                (await Queries.GetEmployeesDataSetAsync())));
        }
    }
}