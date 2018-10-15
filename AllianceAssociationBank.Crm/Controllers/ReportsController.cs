using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Services;
using AllianceAssociationBank.Crm.Exceptions;
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
using X.PagedList;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    [RoutePrefix("Reports")]
    public class ReportsController : Controller
    {
        private IReportGenerationService _reportsService;

        public ReportsController(IReportGenerationService reportsService)
        {
            _reportsService = reportsService;
        }

        [Route("{name}", Name = ReportsControllerRoute.ViewReport)]
        public async Task<ActionResult> ViewReport(string name)
        {
            var reportViewer = await _reportsService.GenerateReportByName(name);

            if (reportViewer == null)
            {
                throw new HttpNotFoundException();
            }

            ViewBag.ReportViewer = reportViewer;
            ViewBag.Title = name;

            return View(ReportsView.ViewReport);
        }
    }
}