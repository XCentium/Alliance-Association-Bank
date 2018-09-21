using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Constants.Notes
{
    public static class NotesControllerRoute
    {
        public const string GetNotes = ControllerName.Notes + "GetNotes";
        public const string CreateNote = ControllerName.Notes + "CreateNote";
        public const string CreateNoteHttpPost = ControllerName.Notes + "CreateNoteHttpPost";
        public const string EditNote = ControllerName.Notes + "EditNote";
        public const string UpdateNote = ControllerName.Notes + "UpdateNote";
        public const string ConfirmDeleteNote = ControllerName.Notes + "ConfirmDeleteNote";
        public const string DeleteNote = ControllerName.Notes + "DeleteNote";
    }
}