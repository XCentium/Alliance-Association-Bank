using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Services;
using AllianceAssociationBank.Crm.Persistence;
using AllianceAssociationBank.Crm.Persistence.Queries;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    [RoutePrefix("Reports")]
    public class ReportsController : Controller
    {
        //private const int _pageSize = 5; // TODO: store this as app config?
        private const string _csvContentType = "text/csv";

        private ReportQueries _queries;
        private ReportGenerationService _reports;

        public ReportsController()
        {
            _queries = new ReportQueries(new CrmApplicationDbContext());
            _reports = new ReportGenerationService(_queries);
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        [Route("{name}", Name = ReportsControllerRoutes.ViewReport)]
        public async Task<ActionResult> ViewReport(string name)
        {
            try
            {
                var reportViewer = await _reports.GenerateReportByName(name);

                ViewBag.ReportViewer = reportViewer;
                ViewBag.Title = name;

                return View(ReportsViews.ViewReport);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //public async Task<ActionResult> BoardingReport(int? page)
        //{
        //    var resultSet = await _queries.GetBoardingReportDataSetAsync();

        //    var pagedResults = Mapper.Map<IEnumerable<ProjectReportRecordViewModel>>(resultSet)
        //        .ToPagedList(page ?? 1, _pageSize);

        //    var model = new ReportViewModel()
        //    {
        //        ResultSet = pagedResults
        //    };
        //    return View(model);
        //}

        public async Task<ActionResult> ExportReportAsCsv(string report)
        {
            var resultSet = await _queries.GetBoardingDataSetAsync();
            var reportRecords = Mapper.Map<IEnumerable<ProjectReportRecordViewModel>>(resultSet);

            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);
            var csvWriter = new CsvWriter(streamWriter);

            csvWriter.WriteRecords(reportRecords);
            streamWriter.Flush();
            memoryStream.Position = 0;

            return File(memoryStream, _csvContentType, $"{report}.csv");
        }

        //public async Task<ActionResult> ExportReportAsPdf(string report)
        //{
        //    var resultSet = await _queries.ExecuteBoardingReportQueryAsync();
        //    var reportRecords = Mapper.Map<IEnumerable<ProjectReportRecordViewModel>>(resultSet);

        //    var memoryStream = new MemoryStream();

        //    var document = new PdfFlowDocument();
        //    document.PageCreated += Document_PageCreated;

        //    var propertyNames = typeof(ProjectReportRecordViewModel).GetProperties().Select(p => p.Name).ToArray();

        //    var dataTable = new PdfFlowTableContent(10/*propertyNames.Count()*/);
        //    dataTable.HeaderRows.AddRowWithCells(propertyNames);

        //    foreach(var obj in reportRecords)
        //    {
        //        var row = new List<object>();

        //        foreach (var prop in propertyNames)
        //        {
        //            var val = obj.GetType().GetProperty(prop).GetValue(obj);
        //            row.Add(val);
        //        }

        //        dataTable.Rows.AddRowWithCells(row.ToArray());
        //    }

        //    /*dataTable.Rows.AddRowWithCells("Project 1", "Somebody", DateTime.Now, true);
        //    dataTable.Rows.AddRowWithCells("Project 2", "Somebody", DateTime.Now, true);
        //    dataTable.Rows.AddRowWithCells("Project 3", "Somebody", DateTime.Now, true);*/

        //    document.AddContent(dataTable);

        //    document.Save(memoryStream);
        //    memoryStream.Position = 0;
        //    return File(memoryStream, "application/pdf", $"{report}.pdf");
        //}

        //private void Document_PageCreated(object sender, PdfFlowPageCreatedEventArgs e)
        //{
        //    e.PageDefaults.Margins.Left = 18;
        //    e.PageDefaults.Margins.Right = 18;
        //    e.PageDefaults.Rotation = 90;
        //}
    }
}