using AllianceAssociationBank.Crm.Constants.CheckScanners;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class ScannerFormViewModel
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        [StringLength(255)]
        public string Model { get; set; }

        [Display(Name = "Serial Number")]
        [StringLength(255)]
        public string SerialNumber { get; set; }

        [StringLength(255)]
        public string System { get; set; }

        [Display(Name = "Comp. Installed On")]
        [StringLength(255)]
        public string ComputerInstalledOn { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Mailed")]
        public DateTime? DateMailed { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Installed")]
        public DateTime? DateInstalled { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Trained")]
        public DateTime? DateTrained { get; set; }

        [Display(Name = "GENERAL NOTES")]
        public string Notes { get; set; }

        public string CreateUpdateRoute
        {
            get
            {
                return (ID != 0) ? CheckScannersControllerRoute.UpdateScanner : CheckScannersControllerRoute.CreateScannerHttpPost;
            }
        }
    }
}