using System.ComponentModel.DataAnnotations;

namespace AllianceAssociationBank.Crm.Core.Models
{
    public class Software
    {
        public int ID { get; set; }

        public string SoftwareName { get; set; }

        public string CurrentSoftware { get; set; }

        public string MigratingTo { get; set; }
    }
}