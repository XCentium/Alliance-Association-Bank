using System;
using System.ComponentModel.DataAnnotations;

namespace AllianceAssociationBank.Crm.Core.Models
{
    public class ProjectUser
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string DI { get; set; }

        public string Sftp { get; set; }

        public string LockboxWeb { get; set; }

        public string EDeposit { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public bool Admin { get; set; }

        public bool CorpOnlineUser { get; set; }

        public bool RemoteScannerUser { get; set; }

        public string RemoteScannerAccountNotes { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? DateAdded { get; set; }

        public DateTime? DateDeleted { get; set; }

        public bool Active { get; set; }

        public string Notes { get; set; }

        public bool AuthorizedToOpenClose { get; set; }

        public bool EnrollmentFormAuthorization { get; set; }

        public bool EmailAuthorization { get; set; }

        public bool StatementEmail { get; set; }

        public bool LockboxEmail { get; set; }

        public bool ACHEmail { get; set; }

        public Project Project { get; set; }


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