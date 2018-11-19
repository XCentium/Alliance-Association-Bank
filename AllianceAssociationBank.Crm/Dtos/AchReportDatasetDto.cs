using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Dtos
{
    public class AchReportDatasetDto
    {
        public int ID { get; set; }

        public string ProjectName { get; set; }

        public string Institution { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string TIN { get; set; }

        public string Fax { get; set; }

        public string Phone { get; set; }

        public string DICompanyID { get; set; }

        public bool ACHPassThru { get; set; }

        public bool ACHBatches { get; set; }

        public decimal? ACHSystemLimit { get; set; }

        public decimal? ACHLimit { get; set; }

        public decimal? ACHEstimatedDeposits { get; set; }

        public DateTime? ACHEstimatedDepositsDate { get; set; }

        public DateTime? OriginalReviewDate { get; set; }

        public DateTime? LastReviewDate { get; set; }

        public bool? Balanced { get; set; }

        public string Narrative { get; set; }

        public bool ACHLimitAndSpecSubmitted { get; set; }

        public bool ACHDualApproval { get; set; }

        public string ACHReviewOfHistoricPerformance { get; set; }

        public string ACHSpectFormInstructions { get; set; }

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

        public string OwnerName { get; set; }
    }
}