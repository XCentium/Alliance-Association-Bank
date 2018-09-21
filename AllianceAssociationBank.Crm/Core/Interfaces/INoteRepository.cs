using System.Collections.Generic;
using System.Threading.Tasks;
using AllianceAssociationBank.Crm.Core.Models;

namespace AllianceAssociationBank.Crm.Core.Interfaces
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetNotes(int projectId);
        Task<Note> GetNoteByIdAsync(int id);
        void AddNote(Note note);
        void RemoveNote(Note note);
        Task<bool> SaveAllAsync();
    }
}