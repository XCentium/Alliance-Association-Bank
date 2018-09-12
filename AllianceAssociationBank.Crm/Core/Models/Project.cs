using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AllianceAssociationBank.Crm.Core.Models
{
    public class Project
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string ProjectName { get; set; }

        [StringLength(255)]
        public string Institution { get; set; }

        public int? OwnerID { get; set; }

        public Employee OwnerEmployee { get; set; }

        public int? AFPID { get; set; }

        public Employee AFPEmployee { get; set; }

        public int? BoardingManagerID { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [StringLength(50)]
        public string Priority { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? TargetLockboxLiveDate { get; set; }

        public string Notes { get; set; }

        [StringLength(8000)]
        public string Attachments { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        [StringLength(255)]
        public string State { get; set; }

        [StringLength(255)]
        public string ZipCode { get; set; }

        [StringLength(255)]
        public string MailingAddress { get; set; }

        [StringLength(255)]
        public string MailingCity { get; set; }

        [StringLength(255)]
        public string MailingState { get; set; }

        [StringLength(255)]
        public string MailingZipCode { get; set; }

        [StringLength(255)]
        public string Website { get; set; }

        [StringLength(255)]
        public string TIN { get; set; }

        [StringLength(255)]
        public string DBA { get; set; }

        [StringLength(255)]
        public string Fax { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Type { get; set; }

        [StringLength(255)]
        public string TimeZone { get; set; }

        //public int? SoftwareID { get; set; }
        [StringLength(255)]
        public string Software { get; set; }

        public int? NumberOfAssociations { get; set; }

        public int? NumberOfDoors { get; set; }

        public decimal? EstimatedDeposits { get; set; }

        public decimal? ActualDeposits { get; set; }

        [StringLength(255)]
        public string CODRate { get; set; }

        public string RateNotes { get; set; }

        [StringLength(10)]
        public string LockboxCMCID { get; set; }

        [StringLength(255)]
        public string POBoxSize { get; set; }

        [StringLength(255)]
        public string POBoxLine1 { get; set; }

        [StringLength(255)]
        public string POBoxZipCode { get; set; }

        public string ScannlineNotes { get; set; }

        public bool/*?*/ EnrollmentFormReceived { get; set; }

        public bool/*?*/ MasterSigCardReceived { get; set; }

        public bool/*?*/ WelcomeEmailSent { get; set; }

        public bool/*?*/ AssociationListReceived { get; set; }

        public bool/*?*/ AssociationAccountsAssigned { get; set; }

        public bool? MgmtCompanyAgreemetnsReceived { get; set; }

        public bool/*?*/ AssociationSignatureCardsSent { get; set; }

        public bool/*?*/ LockboxWanted { get; set; }

        public bool/*?*/ ValidationFileReceived { get; set; }

        public bool? ValidationFileAutomaticRegular { get; set; }

        public string ValidationFileNotes { get; set; }

        public bool? ValidationFileBulkImporterUsed { get; set; }

        public string CouponPrintingNotes { get; set; }

        public bool/*?*/ RemitanceFileTested { get; set; }

        public bool/*?*/ RemitanceFileLife { get; set; }

        public bool/*?*/ LockboxRequestSent { get; set; }

        public bool/*?*/ POBoxAssigned { get; set; }

        public bool/*?*/ ScannerWanted { get; set; }

        public bool/*?*/ MMOnCheckScanner { get; set; }

        public bool? ScannerSent { get; set; }

        public bool? ScannerAQ2SetupRequested { get; set; }

        public bool? ScannerLive { get; set; }

        public bool/*?*/ ACHLimitAndSpecSubmitted { get; set; }

        public bool/*?*/ ACHSuccessfulSubmitted { get; set; }

        public bool/*?*/ OnlineBankingSetup { get; set; }

        public bool/*?*/ OnlineBankingTrained { get; set; }

        public bool/*?*/ CouponsOrdered { get; set; }

        public bool/*?*/ CouponProofReviewed { get; set; }

        [StringLength(255)]
        public string CouponVender { get; set; }

        [StringLength(255)]
        public string CouponVenderNumber { get; set; }

        public bool? DirectDepositPayroll { get; set; }

        public bool? DirectDebitCollection { get; set; }

        public bool? DirectCreditPayments { get; set; }

        public bool? DirectDebitBusinessCCD { get; set; }

        public bool? ConsumerDebitWeb { get; set; }

        [StringLength(255)]
        public string ScannerModel { get; set; }

        [StringLength(255)]
        public string ScannerSerialNumber { get; set; }

        [StringLength(255)]
        public string ScannerProvider { get; set; }

        public string BoardingNextSteps { get; set; }

        public string BoardingNotes { get; set; }

        [StringLength(255)]
        public string Ports { get; set; }

        [StringLength(255)]
        public string DICompanyID { get; set; }

        [StringLength(255)]
        public string DICompanyPassword { get; set; }

        [StringLength(255)]
        public string SftpFolderName { get; set; }

        [StringLength(255)]
        public string SftpGeneralUserName { get; set; }

        [StringLength(255)]
        public string SftpGeneralUserPassword { get; set; }

        public bool? ACHPassThru { get; set; }

        public bool? ACHBatches { get; set; }

        public bool? WireTransferTemplates { get; set; }

        public decimal? ACHEstimatedDeposits { get; set; }

        public DateTime? ACHEstimatedDepositsDate { get; set; }

        public decimal? ACHLimit { get; set; }

        public decimal? ACHSystemLimit { get; set; }

        public DateTime? OriginalReviewDate { get; set; }

        public DateTime? LastReviewDate { get; set; }

        public string ACHReviewNotes { get; set; }

        public string ACHSpectFormInstructions { get; set; }

        public string ACHReviewOfHistoricPerformance { get; set; }

        public bool? ACHDualApproval { get; set; }

        public bool? ACHOneTimePasscode { get; set; }

        [StringLength(255)]
        public string StatementEmail { get; set; }

        [StringLength(255)]
        public string LockboxEmail { get; set; }

        [StringLength(255)]
        public string ACHEmail { get; set; }

        public string AuditNote { get; set; }

        [StringLength(255)]
        public string CIPReviewed { get; set; }

        public bool/*?*/ CIPGood { get; set; }

        public bool? HasCorporateAccounts { get; set; }

        [StringLength(255)]
        public string CorporateAccounts { get; set; }

        public bool? XmlAutoReconSetup { get; set; }

        public bool? XmlAutoReconConfirmedUse { get; set; }

        public DateTime? XmlAutoReconSentDate { get; set; }

        public string Narrative { get; set; }

        public bool? Strongroom { get; set; }

        public bool? EStatements { get; set; }

        [StringLength(255)]
        public string SftpUsage { get; set; }

        [StringLength(255)]
        public string XmlUsage { get; set; }

        public bool? FacsimileSignature { get; set; }

        [StringLength(255)]
        public string ACHReportLaruName { get; set; }

        public bool? Balanced { get; set; }

        public DateTime? LockboxLiveDate { get; set; }

        [StringLength(50)]
        public string LockboxStatus { get; set; }

        [StringLength(50)]
        public string LockboxSystem { get; set; }

        public bool? SftpWithFile { get; set; }

        public bool? SftpManual { get; set; }

        [StringLength(100)]
        public string SftpPath { get; set; }

        [StringLength(100)]
        public string ReformatAQ2 { get; set; }

        [StringLength(100)]
        public string ReformatECP { get; set; }

        public bool? ReformatByAssoc { get; set; }

        //public int? MigratingToSoftwareID { get; set; }
        [StringLength(255)]
        public string MigratingToSoftware { get; set; }

        [StringLength(255)]
        public string OtherName { get; set; }

        [StringLength(50)]
        public string RelationshipRate { get; set; }

        //public virtual ICollection<ProjectUser> Users { get; set; }
    }
}