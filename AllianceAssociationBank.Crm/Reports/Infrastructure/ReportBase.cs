using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using Microsoft.Reporting.WebForms;
using Unity;

namespace AllianceAssociationBank.Crm.Reports.Infrastructure
{
    public abstract class ReportBase
    {
        public virtual ReportViewer ReportViewer { get; }

        protected virtual IReportQueries Queries { get; }

        protected virtual ReportDataSourceCollection DataSources
        {
            get { return ReportViewer.LocalReport.DataSources; }
        }

        protected virtual string ReportsDirectory
        {
            get { return @"Reports\Definitions"; }
        }

        public virtual string ReportDefinitionFileName { get; }

        private IFileSystemService _fileSystem;

        public ReportBase(string reportDefinitionFileName) 
            : this(UnityConfig.Container.Resolve<IReportQueries>(), 
                   UnityConfig.Container.Resolve<IFileSystemService>(), 
                   reportDefinitionFileName)
        {
        }

        public ReportBase(IReportQueries reportQueries, IFileSystemService fileSystem, string reportDefinitionFileName)
        {
            Queries = reportQueries;
            _fileSystem = fileSystem;
            ReportDefinitionFileName = reportDefinitionFileName;

            ReportViewer = InitializeReportViewer();
        }

        protected virtual ReportViewer InitializeReportViewer()
        {
            var reportFileFullPath = GetDefinitionFileFullPath(ReportDefinitionFileName);

            if (!IsValidDefinitionFile(reportFileFullPath))
            {
                throw new InvalidReportException("Cannot locate report definition file.");
            }

            var reportViewer = new ReportViewer();
            reportViewer.LocalReport.ReportPath = reportFileFullPath;
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.AsyncRendering = true;
            reportViewer.SizeToReportContent = true;
            reportViewer.WaitControlDisplayAfter = 1;
            reportViewer.ShowBackButton = false;

            reportViewer.LocalReport.DataSources.Clear();

            return reportViewer;
        }

        protected virtual string GetDefinitionFileFullPath(string reportDefinitionFileName)
        {
            return _fileSystem.GetAppBaseDirectory() + $@"{ReportsDirectory}\{reportDefinitionFileName}.rdlc";
        }

        protected virtual bool IsValidDefinitionFile(string fileFullPath)
        {
            if (_fileSystem.IsFileExists(fileFullPath))
            {
                return true;
            }

            return false;
        }
    }
}