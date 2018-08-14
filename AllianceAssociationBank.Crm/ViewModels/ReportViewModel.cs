using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.PagedList;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class ReportViewModel
    {
        public IPagedList<ProjectReportRecordViewModel> ResultSet { get; set; }
    }
}