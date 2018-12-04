using AllianceAssociationBank.Crm.Helpers;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class HomeViewModel
    {
        public string SelectedReport { get; set; }

        public SelectList ReportsSelectList
        {
            get
            {
                return new SelectList(ReportListHelper.GetStandardReports(), "Value", "Text");
            }
        }

        public string SelectedExport { get; set; }

        public SelectList ExportsSelectList
        {
            get
            {
                return new SelectList(ReportListHelper.GetExports(), "Value", "Text");
            }
        }
    }
}