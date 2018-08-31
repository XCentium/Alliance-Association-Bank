using System;
using System.ComponentModel.DataAnnotations;

namespace AllianceAssociationBank.Crm.Core.Models
{
    public class ProjectUser
    {
        public int ID { get; set; }

        public int? ProjectID { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string DI { get; set; }

        [StringLength(255)]
        public string Sftp { get; set; }

        [StringLength(255)]
        public string LockboxWeb { get; set; }

        [StringLength(255)]
        public string EDeposit { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }

        public byte? Order { get; set; }

        [StringLength(255)]
        public string Mobile { get; set; }

        [StringLength(255)]
        public string Authorization { get; set; }

        public bool Admin { get; set; }

        public bool CorpOnlineUser { get; set; }

        public bool RemoteScannerUser { get; set; }

        [StringLength(255)]
        public string RemoteScannerAccountNotes { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? DateDeleted { get; set; }

        public bool Active { get; set; }

        public string Notes { get; set; }

        [StringLength(8000)]
        public string Attachments { get; set; }

        public bool AuthorizedToOpenClose { get; set; }

        public virtual Project Project { get; set; }


        public void SetDefaultsOnCreate()
        {
            DateAdded = DateTime.Now;
        }

        public void CheckForStatusChange()
        {
            if (!Active && DateDeleted == null)
            {
                DateDeleted = DateTime.Now;
            }
            else if (Active && DateDeleted != null)
            {
                DateDeleted = null;
            }
        }
    }
}