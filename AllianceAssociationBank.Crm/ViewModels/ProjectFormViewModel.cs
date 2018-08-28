using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class ProjectFormViewModel
    {
        // General Tab
        public int ID { get; set; }

        [Required]
        [Display(Name = "Legal")]
        public string ProjectName { get; set; }

        public string DBA { get; set; }

        [Display(Name = "Other")]
        public string OtherName { get; set; } // TODO: need to map this to database

        [Required]
        [Display(Name = "Street")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
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

        [Required]
        public string TIN { get; set; }

        [Display(Name = "TZone")]
        public string TimeZone { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Phone]
        public string Fax { get; set; }

        public string Website { get; set; }

        [Required]
        [Display(Name = "Bank")]
        public string Institution { get; set; }

        [Display(Name = "CD Rate")]
        public string CODRate { get; set; }

        [Display(Name = "Rate Notes")]
        public string RateNotes { get; set; }

        [Required]
        [Display(Name = "Banker")]
        public int? OwnerID { get; set; }

        [Required]
        [Display(Name = "Sales Rep")]
        public int? AFPID { get; set; }

        [Required]
        [Display(Name = "Brd")]
        public int? BoardingManagerID { get; set; }

        [Display(Name = "Software")]
        public int? SoftwareID { get; set; }

        [Display(Name = "System")]
        public string LockboxSystem { get; set; }

        [Display(Name = "HOA")]        
        public int? NumberOfAssociations { get; set; }

        [Display(Name = "Doors")]
        public int? NumberOfDoors { get; set; }

        [Display(Name = "Est'd $")]
        public decimal? EstimatedDeposits { get; set; }

        [Display(Name = "Actual $")]
        public decimal? ActualDeposits { get; set; }

        [Required]
        [Display(Name = "CMC ID")]
        public string LockboxCMCID { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string LockboxStatus { get; set; }

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

        [Display(Name = "NOTES")]
        public string Notes { get; set; }

        public IEnumerable<SelectListItem> ProjectList { get; set; }
        public IEnumerable<SelectListItem> EmployeeList { get; set; }
        public IEnumerable<SelectListItem> SoftwareList { get; set; }
        public IEnumerable<string> InstitutionList { get; set; }
        public IEnumerable<string> LockboxSystemList { get; set; }
        public IEnumerable<string> LockboxStatusList { get; set; }

        // Users Tab
        public IList<UserFormViewModel> Users { get; set; }


        public string CreateUpdateAction
        {
            get
            {
                return (ID != 0) ? "Update" : "Create"; // TODO: need cleaner way to do this
            }
        }

        public ProjectFormViewModel()
        {
            Users = new List<UserFormViewModel>();
        }
    }
}