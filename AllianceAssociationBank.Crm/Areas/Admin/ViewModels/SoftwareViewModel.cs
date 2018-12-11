using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Areas.Admin.ViewModels
{
    public class SoftwareViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Software Name")]
        public string SoftwareName { get; set; }

        public void TrimValues()
        {
            SoftwareName = SoftwareName?.Trim();
        }
    }
}