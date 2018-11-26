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

        public bool MasterSigCardReceived { get; set; }

        public bool EnrollmentFormReceived { get; set; }

        public bool CIPGood { get; set; }

        //public string CIPReviewed { get; set; }

        //public string AuditNote { get; set; }

        public string OwnerName { get; set; }

        public string AFPName { get; set; }
    }
}