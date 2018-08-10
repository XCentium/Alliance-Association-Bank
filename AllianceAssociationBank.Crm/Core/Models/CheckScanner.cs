using System;
using System.ComponentModel.DataAnnotations;


namespace AllianceAssociationBank.Crm.Core.Models
{
    public class CheckScanner
    {
        public int ID { get; set; }

        public int? ProjectID { get; set; }

        [StringLength(255)]
        public string Model { get; set; }

        [StringLength(255)]
        public string SerialNumber { get; set; }

        public DateTime? DateMailed { get; set; }

        public DateTime? DateInstalled { get; set; }

        public DateTime? DateTrained { get; set; }

        [StringLength(255)]
        public string ComputerInstalledOn { get; set; }

        [StringLength(255)]
        public string System { get; set; }

        public string Notes { get; set; }
    }
}