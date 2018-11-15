using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Exceptions;
using Microsoft.Reporting.WebForms;
using Unity;

namespace AllianceAssociationBank.Crm.Reports
{
    public abstract class ReportBase
    {
        public virtual ReportViewer ReportViewer { get; }

        protected virtual IReportQueries Queries { get; }

        protected virtual ReportDataSourceCollection DataSources
        {
            get
            {
                return ReportViewer.LocalReport.DataSources;
            }
        }

        private const string REPORTS_DIRECTORY = "Reports";
        private IFileSystemService _fileSystem;

        public ReportBase(string reportDefinitionFileName)
        {
            _fileSystem = UnityConfig.Container.Resolve<IFileSystemService>();
            Queries = UnityConfig.Container.Resolve<IReportQueries>();

            ReportViewer = InitializeReportViewer(reportDefinitionFileName);
        }

        protected virtual ReportViewer InitializeReportViewer(string reportDefinitionFileName)
        {
            var reportFileFullPath = GetDefinitionFileFullPath(reportDefinitionFileName);

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
            return _fileSystem.GetAppBaseDirectory() + $"{REPORTS_DIRECTORY}\\{reportDefinitionFileName}.rdlc";
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