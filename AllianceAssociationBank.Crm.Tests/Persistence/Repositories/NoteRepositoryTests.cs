using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.ProjectUsers;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Persistence;
using AllianceAssociationBank.Crm.Persistence.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Persistence.Repositories
{
    public class NoteRepositoryTests
    {
        private INoteRepository _noteRepository;
        private Mock<CrmApplicationDbContext> _mockDbContext;
        private Mock<DbSet<Note>> _mockNotesDbSet;

        private List<Note> _notes;
        private int _projectId = 1;

        public NoteRepositoryTests()
        {
            _mockDbContext = new Mock<CrmApplicationDbContext>();
            _mockNotesDbSet = new Mock<DbSet<Note>>();
            _mockDbContext.SetupGet(c => c.Notes).Returns(() => _mockNotesDbSet.Object);

            _noteRepository = new NoteRepository(_mockDbContext.Object);

            _notes = new List<Note>()
            {
                new Note() { ID = 30, ProjectID = 1, NoteText = "Some note 1" },
                new Note() { ID = 31, ProjectID = 2, NoteText = "Some note 2" }
            };
        }

        [Fact]
        public void GetNotes_ValidProjectId_ShouldReturnNotesList()
        {
            _mockNotesDbSet.SetupData(_notes);

            var results = _noteRepository.GetNotes(_projectId);

            Assert.Equal(_notes.Where(u => u.ProjectID == _projectId).Count(), results.Count());
        }

        [Fact]
        public void GetNotes_InvalidProjectId_ShouldReturnEmptyList()
        {
            _mockNotesDbSet.SetupData(_notes);

            var results = _noteRepository.GetNotes(99);

            Assert.Empty(results);
        }

        [Fact]
        public async Task GetNoteByIdAsync_ValidId_ShouldReturnNote()
        {
            _mockNotesDbSet.SetupData(_notes);
            var noteId = _notes.First().ID;

            var result = await _noteRepository.GetNoteByIdAsync(noteId);

            Assert.NotNull(result);
            Assert.Equal(noteId, result.ID);
        }

        [Fact]
        public async Task GetNoteByIdAsync_InvalidId_ShouldReturnNull()
        {
            _mockNotesDbSet.SetupData(_notes);
            var noteId = 99;

            var result = await _noteRepository.GetNoteByIdAsync(noteId);

            Assert.Null(result);
        }

        [Fact]
        public void AddNote_NewNote_ShouldAddEntityToDbSet()
        {
            _mockNotesDbSet.SetupData(_notes);
            var note = new Note()
            {
                ID = 32,
                ProjectID = _projectId,
                NoteText = "Another note"
            };

            _noteRepository.AddNote(note);

            Assert.NotNull(_mockDbContext.Object.Notes.Where(s => s.ID == note.ID).SingleOrDefault());
        }

        [Fact]
        public async Task SaveAllAsync_SaveOneEntity_ShouldReturnTrue()
        {
            _mockNotesDbSet.SetupData(_notes);
            var note = new Note()
            {
                ID = 32,
                ProjectID = _projectId,
                NoteText = "Another note"
            };
            _mockDbContext.Setup(c => c.SaveChangesAsync()).ReturnsAsync(1);

            _noteRepository.AddNote(note);
            var result = await _noteRepository.SaveAllAsync();

            Assert.True(result);
        }
    }
}
