using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AllianceAssociationBank.Crm.Core.Models
{
    public class Project
    {
        public int ID { get; set; }

        public string ProjectName { get; set; }

        public string Institution { get; set; }

        public int? OwnerID { get; set; }

        public Employee Owner { get; set; }

        public int? AFPID { get; set; }

        public Employee AFP { get; set; }

        public int? BoardingManagerID { get; set; }

        public Employee BoardingManager { get; set; }

        public string Status { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? TargetLockboxLiveDate { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string MailingAddress { get; set; }

        public string MailingCity { get; set; }

        public string MailingState { get; set; }

        public string MailingZipCode { get; set; }

        public string Website { get; set; }

        public string TIN { get; set; }

        public string DBA { get; set; }

        public string Fax { get; set; }

        public string Phone { get; set; }

        public string TimeZone { get; set; }

        public string Software { get; set; }

        public int? NumberOfAssociations { get; set; }

        public int? NumberOfDoors { get; set; }

        public decimal? EstimatedDeposits { get; set; }

        public decimal? ActualDeposits { get; set; }

        public string LockboxCMCID { get; set; }

        public string POBoxSize { get; set; }

        public string POBoxLine1 { get; set; }

        public string POBoxZipCode { get; set; }

        public bool EnrollmentFormReceived { get; set; }

        public bool MasterSigCardReceived { get; set; }

        public bool WelcomeEmailSent { get; set; }

        public bool AssociationListReceived { get; set; }

        public bool AssociationAccountsAssigned { get; set; }

        public bool AssociationSignatureCardsSent { get; set; }

        public bool LockboxWanted { get; set; }

        public bool ValidationFileReceived { get; set; }

        public bool ValidationFileAutomaticRegular { get; set; }

        public string ValidationFileNotes { get; set; }

        public bool ValidationFileBulkImporterUsed { get; set; }

        public bool RemitanceFileTested { get; set; }

        public bool RemitanceFileLife { get; set; }

        public bool LockboxRequestSent { get; set; }

        public bool POBoxAssigned { get; set; }

        public bool ScannerWanted { get; set; }

        public bool MMOnCheckScanner { get; set; }

        public bool ACHLimitAndSpecSubmitted { get; set; }

        public bool ACHSuccessfulSubmitted { get; set; }

        public bool OnlineBankingSetup { get; set; }

        public bool OnlineBankingTrained { get; set; }

        public bool CouponsOrdered { get; set; }

        public bool CouponProofReviewed { get; set; }

        public string CouponVender { get; set; }

        public string CouponVenderNumber { get; set; }

        public string BoardingNextSteps { get; set; }

        public string BoardingNotes { get; set; }

        public string DICompanyID { get; set; }

        public string SftpFolderName { get; set; }

        public string SftpGeneralUserPassword { get; set; }

        public bool ACHPassThru { get; set; }

        public bool ACHBatches { get; set; }

        public bool WireTransferTemplates { get; set; }

        public decimal? ACHEstimatedDeposits { get; set; }

        public DateTime? ACHEstimatedDepositsDate { get; set; }

        public decimal? ACHLimit { get; set; }

        public decimal? ACHSystemLimit { get; set; }

        public DateTime? OriginalReviewDate { get; set; }

        public DateTime? LastReviewDate { get; set; }

        public string ACHReviewNotes { get; set; }

        public string ACHSpectFormInstructions { get; set; }

        public string ACHReviewOfHistoricPerformance { get; set; } // TODO: need to revisit this, this field is not on any views

        public bool ACHDualApproval { get; set; }

        public bool CIPGood { get; set; }

        public bool HasCorporateAccounts { get; set; }

        public string CorporateAccounts { get; set; }

        public bool XmlAutoReconSetup { get; set; }

        public DateTime? XmlAutoReconSentDate { get; set; }

        public string Narrative { get; set; }

        public bool Strongroom { get; set; }

        public bool EStatements { get; set; }

        public string SftpUsage { get; set; }

        public string XmlUsage { get; set; }

        public bool FacsimileSignature { get; set; }

        public bool? Balanced { get; set; }

        public DateTime? LockboxLiveDate { get; set; }

        public string LockboxStatus { get; set; }

        public string LockboxSystem { get; set; }

        public bool SftpWithFile { get; set; }

        public bool SftpManual { get; set; }

        public string SftpPath { get; set; }

        public int? ReformatAQ2ID { get; set; }

        public Aq2Reformat ReformatAQ2 { get; set; }

        public bool ReformatByAssoc { get; set; }

        public string MigratingToSoftware { get; set; }

        public string OtherName { get; set; }

        public string RelationshipRate { get; set; }

        public string LockboxNotes { get; set; }

        public bool ACHUploadPPDDebit { get; set; }

        public bool ACHUploadPPDCredit { get; set; }

        public bool ACHUploadCCDDebit { get; set; }

        public bool ACHUploadCCDCredit { get; set; }

        public bool ACHTemplatePPDDebit { get; set; }

        public bool ACHTemplatePPDCredit { get; set; }

        public bool ACHTemplateCCDDebit { get; set; }

        public bool ACHTemplateCCDCredit { get; set; }

        public bool ACHSftpPPDDebit { get; set; }

        public bool ACHSftpPPDCredit { get; set; }

        public bool ACHSftpCCDDebit { get; set; }

        public bool ACHSftpCCDCredit { get; set; }

        public bool ACHWebPPDDebit { get; set; }

        public bool Active { get; set; }

        public ICollection<ProjectUser> Users { get; set; } // removed virtual keyword to disable lazy loading

        public ICollection<CheckScanner> CheckScanners { get; set; } // removed virtual keyword to disable lazy loading
    }
}