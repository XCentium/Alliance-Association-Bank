using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class ProjectDetailViewModel
    {
        // TODO: add Display names
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Address")]
        public string PhysicalAddress { get; set; }
        [Display(Name = "City")]
        public string PhysicalCity { get; set; }
        [Display(Name = "State")]
        public string PhysicalState { get; set; }
        [Display(Name = "Zip Code")]
        public string PhysicalZipCode { get; set; }
        public string TIN { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string RateNotes { get; set; }
        public string LockboxCmdId { get; set; }
        public string Notes { get; set; }
    }
}