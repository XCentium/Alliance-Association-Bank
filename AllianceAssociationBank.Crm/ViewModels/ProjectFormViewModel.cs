using AllianceAssociationBank.Crm.Constants.Projects;
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
        [StringLength(150)]
        [Display(Name = "Legal")]
        public string ProjectName { get; set; }

        [StringLength(255)]
        public string DBA { get; set; }

        [StringLength(255)]
        [Display(Name = "Other")]
        public string OtherName { get; set; } // TODO: This is new field, need to map this to database

        [Required]
        [StringLength(255)]
        [Display(Name = "Street")]
        public string Address { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "ZIP")]
        public string ZipCode { get; set; }

        [StringLength(255)]
        [Display(Name = "Street")]
        public string MailingAddress { get; set; }

        [StringLength(255)]
        [Display(Name = "City")]
        public string MailingCity { get; set; }

        [StringLength(255)]
        [Display(Name = "State")]
        public string MailingState { get; set; }

        [StringLength(255)]
        [Display(Name = "ZIP")]
        public string MailingZipCode { get; set; }

        [StringLength(255)]
        [Required]
        public string TIN { get; set; }

        [StringLength(255)]
        [Display(Name = "TZone")]
        public string TimeZone { get; set; }

        [Required]
        [StringLength(255)]
        [Phone]
        public string Phone { get; set; }

        [StringLength(255)]
        [Phone]
        public string Fax { get; set; }

        [StringLength(255)]
        public string Website { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Bank")]
        public string Institution { get; set; }

        [Display(Name = "Relationship Rate")]
        public string RelationshipRate { get; set; } // TODO: This is new field, need to map to database

        //[StringLength(255)]
        //[Display(Name = "CD Rate")]
        //public string CODRate { get; set; } // This field is going away

        //[Display(Name = "Rate Notes")]
        //public string RateNotes { get; set; } // This field is going away

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

        [Display(Name = "Est'd")]
        public decimal? EstimatedDeposits { get; set; }

        [Display(Name = "Actual")]
        public decimal? ActualDeposits { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "PMC ID")]
        public string LockboxCMCID { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string LockboxStatus { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Live")]
        public DateTime? LockboxLiveDate { get; set; }

        [Display(Name = "Corp Accts")]
        public bool HasCorporateAccounts { get; set; }

        [StringLength(255)]
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

        //public IEnumerable<SelectListItem> ProjectList { get; set; }

        public IEnumerable<SelectListItem> EmployeeList { get; set; }

        public IEnumerable<SelectListItem> SoftwareList { get; set; }

        public IEnumerable<string> InstitutionList { get; set; }

        public IEnumerable<string> LockboxSystemList { get; set; }

        public IEnumerable<string> LockboxStatusList { get; set; }

        // Boarding Tab
        public string Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Enroll. Form Rec'd")]
        public bool EnrollmentFormReceived { get; set; }

        [Display(Name = "Master Sig Card Rec'd")]
        public bool MasterSigCardReceived { get; set; }

        [Display(Name = "Brding Rcp / Welcome Email Sent")]
        public bool WelcomeEmailSent { get; set; }

        [Display(Name = "Assoc. List Rec'd")]
        public bool AssociationListReceived { get; set; }

        [Display(Name = "Assoc. Accounts Assigned")]
        public bool AssociationAccountsAssigned { get; set; }

        [Display(Name = "Assoc. Sig. Cards Sent")]
        public bool AssociationSignatureCardsSent { get; set; }

        [Display(Name = "Set-up Completed")]
        public bool OnlineBankingSetup { get; set; }

        [Display(Name = "Trained")]
        public bool OnlineBankingTrained { get; set; }

        [Display(Name = "Limit, Spec Submitted")]
        public bool ACHLimitAndSpecSubmitted { get; set; }

        [Display(Name = "Successfully Submitted")]
        public bool ACHSuccessfulSubmitted { get; set; }

        [Display(Name = "Wanted")]
        public bool LockboxWanted { get; set; }

        [Display(Name = "PO Box Assigned")]
        public bool POBoxAssigned { get; set; }

        [Display(Name = "Validation File Rec'd")]
        public bool ValidationFileReceived { get; set; }

        [Display(Name = "Lockbox Request Sent")]
        public bool LockboxRequestSent { get; set; }

        [Display(Name = "Remittance File Tested")]
        public bool RemitanceFileTested { get; set; }

        [Display(Name = "Remittance File Live")]
        public bool RemitanceFileLife { get; set; }

        [Display(Name = "Coupons Ordered")]
        public bool CouponsOrdered { get; set; }

        [Display(Name = "Coupon Proof Reviewed")]
        public bool CouponProofReviewed { get; set; }

        [Display(Name = "Wanted")]
        public bool ScannerWanted { get; set; }

        [Display(Name = "MM on Check Scanner")]
        public bool MMOnCheckScanner { get; set; }

        [Display(Name = "BOARDING NEXT STEPS")]
        public string BoardingNextSteps { get; set; }

        [Display(Name = "TIMELINE")]
        public string BoardingNotes { get; set; }

        [Display(Name = "NARRATIVE")]
        public string Narrative { get; set; }

        public IEnumerable<string> StatusList { get; set; }


        public string SaveIndicator { get; set; } = "UNSAVED";

        public string CreateUpdateAction
        {
            get
            {
                return (ID != 0) ? ProjectsControllerAction.Update : ProjectsControllerAction.Create;
            }
        }
    }
}