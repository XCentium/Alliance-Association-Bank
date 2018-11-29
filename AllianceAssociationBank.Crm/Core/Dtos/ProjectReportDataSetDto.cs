using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Core.Dtos
{
    public class ProjectReportDataSetDto
    {
        public int ID { get; set; }

        public string ProjectName { get; set; }

        public string TIN { get; set; }

        public string Software { get; set; }

        public string LockboxCMCID { get; set; }

        public string POBoxLine1 { get; set; }

        public string POBoxZipCode { get; set; }

        public bool MasterSigCardReceived { get; set; }

        public bool EnrollmentFormReceived { get; set; }

        public bool AssociationListReceived { get; set; }

        public bool ValidationFileReceived { get; set; }

        public bool AssociationAccountsAssigned { get; set; }

        //public bool MgmtCompanyAgreemetnsReceived { get; set; }

        public bool AssociationSignatureCardsSent { get; set; }

        public bool OnlineBankingTrained { get; set; }

        //public bool ScannerLive { get; set; }

        public bool CouponProofReviewed { get; set; }

        public string CouponVender { get; set; }

        public string BoardingNextSteps { get; set; }

        public bool CIPGood { get; set; }

        //public string CIPReviewed { get; set; }

        //public string AuditNote { get; set; }

        public string OwnerName { get; set; }

        public string AFPName { get; set; }
    }
}