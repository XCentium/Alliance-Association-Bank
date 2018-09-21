using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace AllianceAssociationBank.Crm.Persistence.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private CrmApplicationDbContext _context;

        public NoteRepository(CrmApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Note> GetNotes(int projectId)
        {
            return _context.Notes
                .OrderByDescending(n => n.DateAdded)
                .Where(n => n.ProjectID == projectId);
        }

        public async Task<Note> GetNoteByIdAsync (int id)
        {
            return await _context.Notes
                .Where(n => n.ID == id)
                .SingleOrDefaultAsync();
        }

        public void AddNote(Note note)
        {
            _context.Notes.Add(note);
        }

        public void RemoveNote(Note note)
        {
            _context.Notes.Remove(note);
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}