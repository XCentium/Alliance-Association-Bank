using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.ProjectUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class UserFormViewModel
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool Active { get; set; }

        public bool Admin { get; set; }

        [Display(Name = "Statement")]
        public bool StatementEmail { get; set; }

        [Display(Name = "Lockbox")]
        public bool LockboxEmail { get; set; }

        [Display(Name = "ACH")]
        public bool ACHEmail { get; set; } 

        [StringLength(255)]
        public string Title { get; set; }

        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [RegularExpression(ValidationRegex.PhoneNumber, ErrorMessage = ValidationErrorMessage.Phone)]
        [StringLength(75)]
        public string Phone { get; set; }

        [RegularExpression(ValidationRegex.PhoneNumber, ErrorMessage = ValidationErrorMessage.Phone)]
        [StringLength(75)]
        public string Mobile { get; set; }

        [Display(Name = "Enroll. Form")]
        public bool EnrollmentFormAuthorization { get; set; }

        [Display(Name = "Email")]
        public bool EmailAuthorization { get; set; }

        [Display(Name = "Open / Close Accounts")]
        public bool AuthorizedToOpenClose { get; set; }

        [StringLength(255)]
        [Display(Name = "Corp Online")]
        public string DI { get; set; }

        public bool CorpOnlineUser { get; set; }

        [StringLength(255)]
        [Display(Name = "E Deposit")]
        public string EDeposit { get; set; }

        public bool RemoteScannerUser { get; set; }

        [StringLength(255)]
        [Display(Name = "Lockbox Web")]
        public string LockboxWeb { get; set; }

        [StringLength(255)]
        [Display(Name = "FTP/SFTP")]
        public string Sftp { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthday { get; set; }

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Inactive")]
        public DateTime? DateDeleted { get; set; }

        [Display(Name = "General Notes")]
        public string Notes { get; set; }

        [StringLength(255)]
        [Display(Name = "Remote Deposit Account Notes")]
        public string RemoteScannerAccountNotes { get; set; }

        public string CreateUpdateRoute
        {
            get
            {
                return (ID != 0) ? ProjectUsersControllerRoute.UpdateUser : ProjectUsersControllerRoute.CreateUserHttpPost;
            }
        }
    }
}