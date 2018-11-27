using AllianceAssociationBank.Crm.Constants.Notes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.ViewModels
{
    public class NoteFormViewModel
    {
        public int ID { get; set; }

        public int ProjectID { get; set; }

        public string NotePreview
        {
            get
            {
                return NoteText?.Length > 92 ? 
                    NoteText.Substring(0, 92) + " ..." : 
                    NoteText;
            }
        }

        [AllowHtml]
        [Required]
        [StringLength(128000)]
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