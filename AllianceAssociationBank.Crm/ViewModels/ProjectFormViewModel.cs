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
        public string OtherName { get; set; }

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

        [Display(Name = "Same as Physical ")]
        public bool MailingSameAsPhysical { get; set; }

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
        public string RelationshipRate { get; set; }

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
        public string SoftwareReadOnly
        {
            get { return Software; }
        }

        [Display(Name = "System")]
        [StringLength(50)]
        public string LockboxSystem { get; set; }

        [Display(Name = "HOA")]        
        public int? NumberOfAssociationsReadOnly
        {
            get { return NumberOfAssociations; }
        }

        [Display(Name = "Doors")]
        public int? NumberOfDoorsReadOnly
        {
            get { return NumberOfDoors; }
        }

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
        [Display(Name = "Live")]
        public DateTime? LockboxLiveDateReadOnly
        {
            get { return LockboxLiveDate; }
        }

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

        //[Display(Name = "NOTES")]
        //public string Notes { get; set; }

        public IEnumerable<SelectListItem> EmployeeList { get; set; }

        public IEnumerable<string> InstitutionList { get; set; }

        public IEnumerable<string> LockboxSystemList { get; set; }

        public IEnumerable<string> LockboxStatusList { get; set; }

        // Boarding Tab
        public string Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End")]
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

        // Software Tab

        [Display(Name = "Software")]
        [StringLength(255)]
        public string Software { get; set; }

        [Display(Name = "Migration")]
        [StringLength(255)]
        public string MigratingToSoftware { get; set; }

        [Display(Name = "Lockbox Wanted")]
        public bool LockboxWantedReadOnly
        {
            get { return LockboxWanted; }
        }

        [Display(Name = "Lockbox Request Sent")]
        public bool LockboxRequestSentReadOnly
        { 
            get { return LockboxRequestSent;  }
        }

        [Display(Name = "XML Auto Recon Setup")]
        public bool XmlAutoReconSetup { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Info Sent")]
        public DateTime? XmlAutoReconSentDate { get; set; }

        public string XmlUsage { get; set; }

        [Display(Name = "Folder Name")]
        [StringLength(255)]
        public string SftpFolderName { get; set; }

        [Display(Name = "AAB SFTP")]
        [StringLength(255)]
        public string SftpGeneralUserPassword { get; set; }

        [Display(Name = "Received")]
        public bool ValidationFileReceivedReadOnly
        {
            get { return ValidationFileReceived; }
        }

        [Display(Name = "Automatic / Regular")]
        public bool ValidationFileAutomaticRegular { get; set; }

        [Display(Name = "Bulk Importer Used")]
        public bool ValidationFileBulkImporterUsed { get; set; }

        public IEnumerable<string> SoftwareList { get; set; }
        
        public IEnumerable<string> MigratingToSoftwareList { get; set; }

        public IEnumerable<string> XmlUsageList { get; set; }

        // Lockbox Tab

        [Display(Name = "PMC ID")]
        [StringLength(10)]
        public string LockboxCMCIDReadOnly
        {
            get { return LockboxCMCID; }
        }

        [Display(Name = "Status")]
        public string LockboxStatusReadOnly
        {
            get { return LockboxStatus; }
        }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Target Live")]
        public DateTime? TargetLockboxLiveDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Actual Live")]
        public DateTime? LockboxLiveDate { get; set; }

        [Display(Name = "Size")]
        [StringLength(255)]
        public string POBoxSize { get; set; }

        [Display(Name = "Line 1")]
        [StringLength(255)]
        public string POBoxLine1 { get; set; }

        [Display(Name = "ZIP")]
        [StringLength(255)]
        public string POBoxZipCode { get; set; }

        [Display(Name = "Assoc's")]
        public int? NumberOfAssociations { get; set; }

        [Display(Name = "Donors")]
        public int? NumberOfDoors { get; set; }

        [Display(Name = "Vendor")]
        [StringLength(255)]
        public string CouponVender { get; set; }

        [Display(Name = "Vendor ID")]
        [StringLength(255)]
        public string CouponVenderNumber { get; set; }

        [Display(Name = "PO Box Assigned")]
        public bool POBoxAssignedReadOnly
        {
            get { return POBoxAssigned; }
        }

        [Display(Name = "Remittance File Tested")]
        public bool RemitanceFileTestedReadOnly
        {
            get { return RemitanceFileTested; }
        }

        [Display(Name = "Remittance File Live")]
        public bool RemitanceFileLifeReadOnly
        {
            get { return RemitanceFileLife; }
        }

        [Display(Name = "Coupons Ordered")]
        public bool CouponsOrderedReadOnly
        {
            get { return CouponsOrdered; }
        }

        [Display(Name = "Coupon Proof Reviewed")]
        public bool CouponProofReviewedReadOnly
        {
            get { return CouponProofReviewed; }
        }

        [Display(Name = "AQ2")]
        public int? ReformatAQ2ID { get; set; }

        //[Display(Name = "ECP")]
        //public int? ReformatECPID { get; set; } // This is not needed anymore

        [Display(Name = "By Association")]
        public bool ReformatByAssoc { get; set; }

        [Display(Name = "Bulk Importer Used")]
        public bool ValidationFileBulkImporterUsedReadOnly
        {
            get { return ValidationFileBulkImporterUsed; }
        }

        [Display(Name = "SFTP with File")]
        public bool SftpWithFile { get; set; }

        [Display(Name = "Manual")]
        public bool SftpManual { get; set; }

        [Display(Name = "SFTP Path")]
        [StringLength(100)]
        public string SftpPath { get; set; }

        [Display(Name = "LOCKBOX NOTES")]
        public string LockboxNotes { get; set; }

        public IEnumerable<SelectListItem> Aq2ReformatList { get; set; }

        // ACH Tab

        [Display(Name = "Upload - PPD")]
        public bool ACHUploadPPDDebit { get; set; }
        public bool ACHUploadPPDCredit { get; set; }

        [Display(Name = "Upload - CCD")]
        public bool ACHUploadCCDDebit { get; set; }
        public bool ACHUploadCCDCredit { get; set; }

        [Display(Name = "Template - PPD")]
        public bool ACHTemplatePPDDebit { get; set; }
        public bool ACHTemplatePPDCredit { get; set; }

        [Display(Name = "Template - CCD")]
        public bool ACHTemplateCCDDebit { get; set; }
        public bool ACHTemplateCCDCredit { get; set; }

        [Display(Name = "SFTP - PPD")]
        public bool ACHSftpPPDDebit { get; set; }
        public bool ACHSftpPPDCredit { get; set; }

        [Display(Name = "SFTP - CCD")]
        public bool ACHSftpCCDDebit { get; set; }
        public bool ACHSftpCCDCredit { get; set; }

        [Display(Name = "Web - PPD")]
        public bool ACHWebPPDDebit { get; set; }

        public bool? Balanced { get; set; }

        [Display(Name = "Wire Transfer Template")]
        public bool WireTransferTemplates { get; set; }
    
        [Display(Name = "Dual approval Opt-out")]
        public bool ACHDualApproval { get; set; }

        //[Display(Name = "ACH Limit & Spec Submitted")]
        //public bool ACHLimitAndSpecSubmittedReadOnly
        //{
        //    get { return ACHLimitAndSpecSubmitted; }
        //}

        //[Display(Name = "ACH Successfully Submitted")]
        //public bool ACHSuccessfulSubmittedReadOnly
        //{
        //    get { return ACHSuccessfulSubmitted; }
        //}

        [Display(Name = "Est. Deposits")]
        public decimal? ACHEstimatedDeposits { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Est. $")]
        public DateTime? ACHEstimatedDepositsDate { get; set; }

        [Display(Name = "Limit")]
        public decimal? ACHLimit { get; set; }

        [Display(Name = "System Limit")]
        public decimal? ACHSystemLimit { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Original Review")]
        public DateTime? OriginalReviewDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Review")]
        public DateTime? LastReviewDate { get; set; }

        [Display(Name = "OLB/BST ID")]
        [StringLength(255)]
        public string DICompanyID { get; set; }

        [Display(Name = "REVIEW NOTES & HISTORY")]
        public string ACHReviewNotes { get; set; }

        [Display(Name = "SPEC SHEET")]
        public string ACHSpectFormInstructions { get; set; }

        // System Tab

        [Display(Name = "OLB/BST ID")]
        [StringLength(255)]
        public string DICompanyIDReadOnly
        {
            get { return DICompanyID; }
        }

        [Display(Name = "Bank")]
        public string InstitutionReadOnly
        {
            get { return Institution; }
        }

        [Display(Name = "Online Banking Set-up")]
        public bool OnlineBankingSetupReadOnly
        {
            get { return OnlineBankingSetup; }
        }

        [Display(Name = "Online Banking Trained")]
        public bool OnlineBankingTrainedReadOnly
        {
            get { return OnlineBankingTrained; }
        }

        [Display(Name = "ACH PassThru / Upload")]
        public bool ACHPassThru { get; set; }

        [Display(Name = "ACH Batches / Template")]
        public bool ACHBatches { get; set; }

        [Display(Name = "Wire Transfer Template")]
        public bool WireTransferTemplatesReadOnly
        {
            get { return WireTransferTemplates; }
        }

        [Display(Name = "Folder Name")]
        public string SftpFolderNameReadOnly
        {
            get { return SftpFolderName;  }
        }

        [Display(Name = "AAB SFTP")]
        public string SftpGeneralUserPasswordReadOnly
        {
            get { return SftpGeneralUserPassword; }
        }

        [Display(Name = "USAGE")]
        [StringLength(255)]
        public string SftpUsage { get; set; }

        [Display(Name = "Automatic / Regular")]
        public bool ValidationFileAutomaticRegularReadOnly
        {
            get { return ValidationFileAutomaticRegular; }
        }     

        [Display(Name = "ACH File Type")]
        public bool? BalancedReadOnly
        {
            get { return Balanced; }
        }


        public string SaveIndicator { get; set; } = "UNSAVED";

        public string SaveIndicatorCssClass
        {
            get
            {
                return SaveIndicator == "SAVED" ?
                                        "badge-success" :
                                        "badge-light";
            }
        }

        public string CreateUpdateAction
        {
            get
            {
                return (ID != 0) ? ProjectsControllerAction.Update : ProjectsControllerAction.Create;
            }
        }

        public void ResetCmcIdOnUnauthorized(IPrincipal user, string currentValue)
        {
            if (user == null)
            {
                LockboxCMCID = currentValue;
            }
            else if (!user.IsInRole(UserRole.Admin) && !string.IsNullOrEmpty(currentValue))
            {
                LockboxCMCID = currentValue;
            }
        }
    }
}