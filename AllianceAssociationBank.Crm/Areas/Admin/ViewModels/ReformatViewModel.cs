using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Areas.Admin.ViewModels
{
    public class ReformatViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string ReformatName { get; set; }

        public void TrimValues()
        {
            ReformatName = ReformatName?.Trim();
        }
    }
}