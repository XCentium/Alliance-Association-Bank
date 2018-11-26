﻿using System;
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

        public string Phone { get; set; }

        public string LockboxCMCID { get; set; }

        public string Status { get; set; }

        public string POBoxLine1 { get; set; }

        public string OwnerName { get; set; }

        public string AFPName { get; set; }
    }
}