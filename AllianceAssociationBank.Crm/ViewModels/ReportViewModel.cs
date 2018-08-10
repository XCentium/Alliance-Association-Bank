using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class ReportViewModel
    {
        public string ReportName { get; set; }
        public IEnumerable<Project> ResultSet { get; set; }
        public int TotalRecords { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }


    }
}