using AllianceAssociationBank.Crm.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Core.Dtos
{
    public class IncorrectEmployeeDatasetDto
    {
        public int ID { get; set; }

        public string ProjectName { get; set; }

        public int? OwnerID { get; set; }

        public string OwnerName { get; set; }

        public int? AFPID { get; set; }

        public string AFPName { get; set; }

        public int? BoardingManagerID { get; set; }

        public string BoardingManagerName { get; set; }
    }
}