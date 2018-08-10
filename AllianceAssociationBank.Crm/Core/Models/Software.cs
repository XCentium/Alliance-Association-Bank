using System.ComponentModel.DataAnnotations;

namespace AllianceAssociationBank.Crm.Core.Models
{
    public class Software
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string SoftwareName { get; set; }

        [StringLength(255)]
        public string CurrentSoftware { get; set; }

        [StringLength(255)]
        public string MigratingTo { get; set; }
    }
}