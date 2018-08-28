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

        //public int ProjectID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Mobile { get; set; }

        public bool Active { get; set; }

        public bool Admin { get; set; }

        public string Authorization { get; set; }

        public bool AuthorizedToOpenClose { get; set; }

        [StringLength(255)]
        public string DI { get; set; }

        public bool CorpOnlineUser { get; set; }

        [StringLength(255)]
        public string EDeposit { get; set; }

        public bool RemoteScannerUser { get; set; }

        [StringLength(255)]
        public string LockboxWeb { get; set; }

        [StringLength(255)]
        public string Sftp { get; set; }

        public DateTime? Birthday { get; set; }

        public string Notes { get; set; }

        [StringLength(255)]
        public string RemoteScannerAccountNotes { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? DateDeleted { get; set; }

        //public byte? Order { get; set; }

        //[StringLength(8000)]
        //public string Attachments { get; set; }

        public string CreateUpdateAction
        {
            get
            {
                return (ID != 0) ? "Update" : "Create"; // TODO: need cleaner way to do this
            }
        }
    }
}