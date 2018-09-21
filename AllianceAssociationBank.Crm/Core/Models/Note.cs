using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Core.Models
{
    public class Note
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public string NoteText { get; set; }

        public DateTime DateAdded { get; set; }

        public void SetDefaultsOnCreate()
        {
            DateAdded = DateTime.Now;
        }
    }
}