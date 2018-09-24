using AllianceAssociationBank.Crm.Constants.Notes;
using System;
using System.ComponentModel.DataAnnotations;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class NoteViewModel
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public string NotePreview
        {
            get { return NoteText?.Length > 100 ? 
                    NoteText.Substring(0, 137) + " ..." : 
                    NoteText; }
        }

        [Required]
        [Display(Name = "Note Text")]
        public string NoteText { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateAdded { get; set; }

        public string CreateUpdateRoute
        {
            get
            {
                return (ID != 0) ? NotesControllerRoute.UpdateNote : NotesControllerRoute.CreateNoteHttpPost;
            }
        }
    }
}