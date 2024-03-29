﻿using AllianceAssociationBank.Crm.Constants.Reports;
using AllianceAssociationBank.Crm.Core.Interfaces;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace AllianceAssociationBank.Crm.Core.Services
{
    [Obsolete("This service class been deprecated and replaced with ReportBase class and IReport interface.")]
    public class ReportGenerationService : IReportGenerationService
    {
        private IReportQueries _queries;
        private IFileSystemService _fileSystem;
        private const string REPORTS_DIRECTORY = "Reports";

        public ReportGenerationService(IReportQueries queries, IFileSystemService fileSystem)
        {
            _queries = queries;
            _fileSystem = fileSystem;
        }

        public async Task<ReportViewer> GenerateReportByName(string reportName, int? projectId = null)
        {
            var reportPath = _fileSystem.GetAppBaseDirectory() + $"{REPORTS_DIRECTORY}\\{reportName}.rdlc";

            // if report rdlc file doesn't exist return null
            if (!_fileSystem.IsFileExists(reportPath))
            {
                return null;
            }

            var reportViewer = new ReportViewer();
            reportViewer.LocalReport.ReportPath = reportPath;
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.AsyncRendering = true;
            reportViewer.SizeToReportContent = true;
            reportViewer.WaitControlDisplayAfter = 1;
            reportViewer.ShowBackButton = false;

            reportViewer.LocalReport.DataSources.Clear();
            foreach (var dataSource in (await GetDataSourcesByReportName(reportName, projectId)))
            {
                reportViewer.LocalReport.DataSources.Add(dataSource);
            }

            return reportViewer;
        }

        private async Task<IEnumerable<ReportDataSource>> GetDataSourcesByReportName(string reportName, int? projectId = null)
        {
            var dataSources = new Collection<ReportDataSource>();

            switch (reportName)
            {
                case var name when name.Equals(ReportName.Boarding, StringComparison.InvariantCultureIgnoreCase):
                    {
                        dataSources.Add(new ReportDataSource(ReportDataSetName.Projects, (await _queries.GetBoardingDataSetAsync())));
                        dataSources.Add(new ReportDataSource(ReportDataSetName.Employees, (await _queries.GetEmployeesDataSetAsync())));
                        break;
                    }
                case var name when name.Equals(ReportName.CompletedAndHold, StringComparison.InvariantCultureIgnoreCase):
                    {
                        dataSources.Add(new ReportDataSource(ReportDataSetName.Projects, (await _queries.GetCompletedAndHoldDataSetAsync())));
                        dataSources.Add(new ReportDataSource(ReportDataSetName.Employees, (await _queries.GetEmployeesDataSetAsync())));
                        break;
                    }
                case var name when name.Equals(ReportName.SoftwareTransition, StringComparison.InvariantCultureIgnoreCase):
                    {
                        dataSources.Add(new ReportDataSource(ReportDataSetName.Projects, (await _queries.GetSoftwareTransitionDataSetAsync())));
                        dataSources.Add(new ReportDataSource(ReportDataSetName.Employees, (await _queries.GetEmployeesDataSetAsync())));
                        break;
                    }
                case var name when name.Equals(ReportName.CmcById, StringComparison.InvariantCultureIgnoreCase):
                    {
                        dataSources.Add(new ReportDataSource(ReportDataSetName.Master, (await _queries.GetCmcByIdDataSetAsync())));
                        break;
                    }
                case var name when name.Equals(ReportName.CmcByName, StringComparison.InvariantCultureIgnoreCase):
                    {
                        dataSources.Add(new ReportDataSource(ReportDataSetName.Master, (await _queries.GetCmcByNameDataSetAsync())));
                        break;
                    }
                case var name when name.Equals(ReportName.CDEmails, StringComparison.InvariantCultureIgnoreCase):
                    {
                        dataSources.Add(new ReportDataSource(ReportDataSetName.CDEmails, (await _queries.GetCDEmailsDataSetAsync())));
                        break;
                    }
                case var name when name.Equals(ReportName.Coupon, StringComparison.InvariantCultureIgnoreCase):
                    {
                        dataSources.Add(new ReportDataSource(ReportDataSetName.Projects, (await _queries.GetCouponDataSetAsync())));
                        dataSources.Add(new ReportDataSource(ReportDataSetName.Employees, (await _queries.GetEmployeesDataSetAsync())));
                        break;
                    }
                case var name when name.Equals(ReportName.AchSpec, StringComparison.InvariantCultureIgnoreCase):
                    {
                        dataSources.Add(new ReportDataSource(ReportDataSetName.AchReport, (await _queries.GetAchReportDataSetAsync((int)projectId))));
                        break;
                    }
                case var name when name.Equals(ReportName.AchInitialReview, StringComparison.InvariantCultureIgnoreCase):
                    {
                        dataSources.Add(new ReportDataSource(ReportDataSetName.AchReport, (await _queries.GetAchReportDataSetAsync((int)projectId))));
                        break;
                    }
                case var name when name.Equals(ReportName.AchSixMonthReview, StringComparison.InvariantCultureIgnoreCase):
                    {
                        dataSources.Add(new ReportDataSource(ReportDataSetName.AchReport, (await _queries.GetAchReportDataSetAsync((int)projectId))));
                        break;
                    }
            }

            return dataSources;
        }
    }
}