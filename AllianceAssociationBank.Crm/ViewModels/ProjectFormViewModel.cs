using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class ProjectFormViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string ProjectName { get; set; }
        public string DBA { get; set; }
        [Display(Name = "Street")]
        public string Address { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "ZIP")]
        public string ZipCode { get; set; }
        [Display(Name = "Street")]
        public string MailingAddress { get; set; }
        [Display(Name = "City")]
        public string MailingCity { get; set; }
        [Display(Name = "State")]
        public string MailingState { get; set; }
        [Display(Name = "ZIP")]
        public string MailingZipCode { get; set; }
        public string TIN { get; set; }
        [Display(Name = "TZone")]
        public string TimeZone { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        [Display(Name = "Bank")]
        public string Institution { get; set; }
        [Display(Name = "CD Rate")]
        public string CODRate { get; set; }
        [Display(Name = "Rate Notes")]
        public string RateNotes { get; set; }

        [Display(Name = "Ops")]
        public int? OwnerID { get; set; }
        [Display(Name = "Sales")]
        public int? AFPID { get; set; }
        [Display(Name = "Brd")]
        public int? BoardingManagerID { get; set; }
        [Display(Name = "Software")]
        public int? SoftwareID { get; set; }

        [Display(Name = "Lockbox System")]
        public string LockboxSystem { get; set; }
        [Display(Name = "HOA")]
        public int? NumberOfAssociations { get; set; }
        [Display(Name = "Doors")]
        public int? NumberOfDoors { get; set; }
        [Display(Name = "Est'd $")]
        public decimal? EstimatedDeposits { get; set; }
        [Display(Name = "Actual $")]
        public decimal? ActualDeposits { get; set; }
        [Display(Name = "CMC ID")]
        public string LockboxCmdId { get; set; }
        [Display(Name = "Lockbox Status")]
        public string LockboxStatus { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Live")]
        public DateTime? LockboxLiveDate { get; set; }
        [Display(Name = "Corp Accts")]
        public bool HasCorporateAccounts { get; set; }
        [Display(Name = "Corp Accts")]
        public string CorporateAccounts { get; set; }
        [Display(Name = "Strongroom")]
        public bool Strongroom { get; set; }
        [Display(Name = "E-statemnt")]
        public bool EStatements { get; set; }
        [Display(Name = "Fax Sig")]
        public bool FacsimileSignature { get; set; }
        public string Notes { get; set; }

        //public int? SelectedProjectId { get; set; }
        public IEnumerable<SelectListItem> ProjectList { get; set; }
        public IEnumerable<SelectListItem> EmployeeList { get; set; }
        public IEnumerable<SelectListItem> SoftwareList { get; set; }
        public IEnumerable<string> LockboxSystemList { get; set; }
        public IEnumerable<string> LockboxStatusList { get; set; }

        public string CreateUpdateAction
        {
            get
            {
                return (ID != 0) ? "Update" : "Create"; // TODO: need cleaner way to do this
            }
        }
    }
}