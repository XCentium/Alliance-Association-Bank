using AllianceAssociationBank.Crm.Persistence;
using AllianceAssociationBank.Crm.Persistence.Queries;
using AllianceAssociationBank.Crm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    public class ReportsController : Controller
    {
        private ReportQueries _queries;
        private const int _pageSize = 10;

        public ReportsController()
        {
            _queries = new ReportQueries(new CrmApplicationDbContext());
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> BoardingReport()
        {
            var resultSet = await _queries.ExecuteBoardingReportQueryAsync();

            var totalCount = resultSet.Count();
            var model = new ReportViewModel()
            {
                ReportName = "Boarding Report",
                ResultSet = resultSet,
                TotalRecords = totalCount,
                TotalPages = totalCount/_pageSize
            };

            return View(model);
        }
    }
}