using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Projects;
using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class SearchResultViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Legal Name")]
        public string ProjectName { get; set; }

        public string DBA { get; set; }

        [Display(Name = "Other")]
        public string OtherName { get; set; }

        public string TIN { get; set; }

        public string Phone { get; set; }

        [Display(Name = "PMC ID")]
        public string LockboxCMCID { get; set; }
    }
}