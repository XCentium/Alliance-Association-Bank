using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AllianceAssociationBank.Crm.Extensions
{
    public static class ReportViewerExtensions
    {
        public static void SetProperties(this ReportViewer reportViewer, ReportViewer properties)
        {
            if (reportViewer == null)
            {
                throw new ArgumentNullException("reportViewer", "Value cannot be null.");
            }

            if (properties == null)
            {
                throw new ArgumentNullException("properties", "Value cannot be null.");
            }

            reportViewer.ProcessingMode = properties.ProcessingMode;
            reportViewer.LocalReport.ReportPath = properties.LocalReport.ReportPath;
            reportViewer.AsyncRendering = properties.AsyncRendering;
            reportViewer.SizeToReportContent = properties.SizeToReportContent;
            reportViewer.Width = properties.Width;
            reportViewer.Height = properties.Height;
            reportViewer.WaitControlDisplayAfter = properties.WaitControlDisplayAfter;
            reportViewer.ShowBackButton = properties.ShowBackButton;
            reportViewer.LocalReport.DataSources.Clear();
            foreach (var dataSource in properties.LocalReport.DataSources)
            {
                reportViewer.LocalReport.DataSources.Add(dataSource);
            }
        }
    }
}