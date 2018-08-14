﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class ProjectDetailViewModel
    {
        //public int? SelectedProjectId { get; set; }
        public IEnumerable<SelectListItem> Projects { get; set; }

        public int ID { get; set; }
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Display(Name = "Physical Address")]
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        [Display(Name = "Mailing Address")]
        public string MailingAddress { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingZipCode { get; set; }
        public string TIN { get; set; }
        [Display(Name = "Time Zone")]
        public string TimeZone { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        [Display(Name = "Bank")]
        public string Institution { get; set; }
        [Display(Name = "COD Rate")]
        public string CODRate { get; set; }
        [Display(Name = "Rate Notes")]
        public string RateNotes { get; set; }

        [Display(Name = "Ops")]
        public int? OwnerID { get; set; }
        [Display(Name = "Sls")]
        public int? AFPID { get; set; }
        [Display(Name = "Brd")]
        public int? BoardingManagerID { get; set; }
        [Display(Name = "Software")]
        public int? SoftwareID { get; set; }

        [Display(Name = "Lockbox System")]
        public string LockboxSystem { get; set; }
        [Display(Name = "Number of HOA")]
        public int? NumberOfAssociations { get; set; }
        [Display(Name = "Number of Doors")]
        public int? NumberOfDoors { get; set; }
        [Display(Name = "Estimated $")]
        public decimal? EstimatedDeposits { get; set; }
        [Display(Name = "Actual $")]
        public decimal? ActualDeposits { get; set; }
        [Display(Name = "CMC ID")]
        public string LockboxCmdId { get; set; }
        [Display(Name = "Lockbox Status")]
        public string LockboxStatus { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Live Date")]
        public DateTime? LockboxLiveDate { get; set; }
        [Display(Name = "CorporateAccounts")]
        public bool HasCorporateAccounts { get; set; }
        public string CorporateAccounts { get; set; }
        [Display(Name = "Strongroom")]
        public bool Strongroom { get; set; }
        [Display(Name = "E-Statements")]
        public bool EStatements { get; set; }
        [Display(Name = "Facsimile Signature")]
        public bool FacsimileSignature { get; set; }
        public string Notes { get; set; }
    }
}