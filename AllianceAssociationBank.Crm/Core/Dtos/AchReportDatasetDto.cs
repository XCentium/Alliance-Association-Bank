using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Core.Dtos
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

        public bool? ACHPassThru { get; set; }

        public bool? ACHBatches { get; set; }

        public decimal? ACHSystemLimit { get; set; }

        public decimal? ACHLimit { get; set; }

        public decimal? ACHEstimatedDeposits { get; set; }

        public DateTime? OriginalReviewDate { get; set; }

        public DateTime? LastReviewDate { get; set; }

        public bool? Balanced { get; set; }

        public string Narrative { get; set; }

        public string ACHReviewOfHistoricPerformance { get; set; }

        public string ACHSpectFormInstructions { get; set; }

        public string OwnerName { get; set; }

        public string ContactName { get; set; }

        public string ContactEmail { get; set; }
    }
}