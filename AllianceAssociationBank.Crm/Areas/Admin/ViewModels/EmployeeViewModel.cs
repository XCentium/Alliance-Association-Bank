using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Areas.Admin.ViewModels
{
    public class EmployeeViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public void TrimValues()
        {
            FirstName = FirstName?.Trim();
            LastName = LastName?.Trim();
        }
    }
}