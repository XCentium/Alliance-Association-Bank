using System;
using System.ComponentModel.DataAnnotations;


namespace AllianceAssociationBank.Crm.Core.Models
{
    public class CheckScanner
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public string Model { get; set; }

        public string SerialNumber { get; set; }

        public DateTime? DateMailed { get; set; }

        public DateTime? DateInstalled { get; set; }

        public DateTime? DateTrained { get; set; }

        public string ComputerInstalledOn { get; set; }

        public string System { get; set; }

        public string Notes { get; set; }

        public Project Project { get; set; }
    }
}