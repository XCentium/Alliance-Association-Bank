using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Core.Dtos
{
    public class CmcReportDataSetDto
    {
        public int ID { get; set; }

        public string ProjectName { get; set; }

        public string TIN { get; set; }

        public string DICompanyID { get; set; }

        public string Software { get; set; }

        public decimal? ACHSystemLimit { get; set; }

        public string ValidationFileNotes { get; set; }

        public string MailingAddress { get; set; }

        public string MailingCity { get; set; }

        public string MailingState { get; set; }

        public string MailingZipCode { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Phone { get; set; } // Should delete this?

        public string LockboxCMCID { get; set; }

        public string Status { get; set; }

        public string POBoxLine1 { get; set; }

        public string OwnerName { get; set; }

        public string AFPName { get; set; }

        public bool ACHPassThru { get; set; }

        public bool ACHBatches { get; set; }

        public bool WireTransferTemplates { get; set; }

        public bool MasterSigCardReceived { get; set; }

        public bool EnrollmentFormReceived { get; set; }

        public bool CIPGood { get; set; }

        public bool LockboxWanted { get; set; }

        public bool ValidationFileAutomaticRegular { get; set; }

        public bool ValidationFileReceived { get; set; }

        public bool ValidationFileBulkImporterUsed { get; set; }

        public string CheckScannerSerialNumbers { get; set; }

        public string CheckScannerModels { get; set; }
    }
}