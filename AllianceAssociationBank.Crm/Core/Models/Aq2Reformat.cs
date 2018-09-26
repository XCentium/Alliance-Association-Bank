using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Core.Models
{
    public class Aq2Reformat
    {
        public int ID { get; set; }

        public string ReformatName { get; set; }

        public string Description { get; set; }

        public string ECPReformatSpec { get; set; }

        public string ECPPriorityOrder { get; set; }
    }
}