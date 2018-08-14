using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class ProjectReportRecordViewModel
    {
        public int ID { get; set; }

        public string ProjectName { get; set; }

        public int? OwnerID { get; set; }

        public int? AFPID { get; set; }

        public int? BoardingManagerID { get; set; }

        //public string Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? StartDate { get; set; }

        //public DateTime? EndDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? TargetLockboxLiveDate { get; set; }

        public int? SoftwareID { get; set; }

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

        public bool LockboxRequestSent { get; set; }

        public bool ScannerWanted { get; set; }

        public bool ACHLimitAndSpecSubmitted { get; set; }

        public bool ACHSuccessfulSubmitted { get; set; }

        public bool OnlineBankingSetup { get; set; }

        public bool OnlineBankingTrained { get; set; }

        public bool CouponsOrdered { get; set; }

        public bool CouponProofReviewed { get; set; }

        public string CouponVender { get; set; }

        public string BoardingNextSteps { get; set; }

        public string BoardingNotes { get; set; }

        public bool CIPGood { get; set; }
    }
}