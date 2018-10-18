using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.CheckScanners;
using AllianceAssociationBank.Crm.Constants.Notes;
using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Mappings;
using AllianceAssociationBank.Crm.Tests.Helpers;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Controllers
{
    public class NotesControllerTests
    {
        private NotesController controller;
        private IMapper mapper;

        private Mock<INoteRepository> notesRepoMock;

        private NoteFormViewModel noteViewModel;
        private Note note;

        public NotesControllerTests()
        {
            notesRepoMock = new Mock<INoteRepository>();
            mapper = CrmAutoMapperProfile.GetMapper();

            controller = new NotesController(notesRepoMock.Object, mapper);
            // Mock http context so http response object is not null
            var response = new Mock<HttpResponseBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Response).Returns(response.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);

            note = new Note()
            {
                ID = 1001,
                ProjectID = 101,
                NoteText = "Some Note"
            };

            noteViewModel = new NoteFormViewModel()
            {
                ID = note.ID,
                ProjectID = note.ProjectID,
                NoteText = note.NoteText
            };
        }

        [Fact]
        public void Index_ValidProjectId_ShouldReturnPartialView()
        {
            var notes = new List<Note>()
            {
                new Note()
                {
                    ID = 1002,
                    ProjectID = 99
                },
                new Note()
                {
                    ID = 1003,
                    ProjectID = 99
                }
            };
            var projectId = 99;
            notesRepoMock.Setup(r => r.GetNotes(projectId)).Returns(notes);

            var result = controller.Index(projectId);

            TestHelper.AssertActionResult<PartialViewResult, Collection<NoteFormViewModel>>
            (
                result, 
                NotesView.NotesListPartial,
                notes.Count
            );
        }

        [Fact]
        public void Index_InvalidProjectId_ShouldReturnPartialViewWithZeroRecords()
        {
            var projectId = 99;

            var result = controller.Index(projectId);

            TestHelper.AssertActionResult<PartialViewResult, Collection<NoteFormViewModel>>
            (
                result,
                NotesView.NotesListPartial,
                0
            );
        }

        [Fact]
        public void Create_NewNoteEntry_ShouldReturnPartialView()
        {
            var projectId = 99;

            var result = controller.Create(projectId);

            TestHelper.AssertActionResult<PartialViewResult, NoteFormViewModel>
            (
                result,
                NotesView.NoteFormPartial
            );
        }

        [Fact]
        public async Task Create_ValidInputModel_ShouldReturnPartialView()
        {
            var projectId = 99;
            noteViewModel.ID = 0; // On create Id should be 0
            noteViewModel.ProjectID = projectId;
            notesRepoMock.Setup(r => r.SaveAllAsync()).ReturnsAsync(true);

            var result = await controller.Create(projectId, noteViewModel);

            TestHelper.AssertActionResult<PartialViewResult, Collection<NoteFormViewModel>>
            (
                result,
                NotesView.NotesListPartial
            );
        }

        [Fact]
        public async Task Edit_ValidNoteId_ShouldReturnPartialView()
        {
            var noteId = note.ID;
            notesRepoMock.Setup(r => r.GetNoteByIdAsync(noteId)).ReturnsAsync(note);

            var result = await controller.Edit(99, noteId);

            TestHelper.AssertActionResult<PartialViewResult, NoteFormViewModel>
            (
                result,
                NotesView.NoteFormPartial
            );
        }

        [Fact]
        public async Task Edit_InvalidNoteId_ShouldReturnJsonError()
        {
            var noteId = 1;
            notesRepoMock.Setup(r => r.GetNoteByIdAsync(noteId)).ReturnsAsync(null as Note);

            var result = await controller.Edit(99, noteId);

            var notFoundResult = Assert.IsType<JsonErrorResult>(result);
        }

        [Fact]
        public async Task Update_ValidInputModel_ShouldReturnPartialView()
        {
            var projectId = noteViewModel.ProjectID;
            var noteId = noteViewModel.ID;
            noteViewModel.NoteText = "Updated note";
            notesRepoMock.Setup(r => r.GetNoteByIdAsync(noteId)).ReturnsAsync(note);
            notesRepoMock.Setup(r => r.SaveAllAsync()).ReturnsAsync(true);

            var result = await controller.Update(projectId, noteId, noteViewModel);

            TestHelper.AssertActionResult<PartialViewResult, Collection<NoteFormViewModel>>
            (
                result,
                NotesView.NotesListPartial
            );
        }

        [Fact]
        public async Task Update_InvalidInputModel_ShouldReturnPartialViewWithBadRequestStatusCode()
        {
            var projectId = noteViewModel.ProjectID;
            var noteId = noteViewModel.ID;
            noteViewModel.NoteText = null;
            controller.ModelState.AddModelError("NoteText", "The Note Text field is required.");

            var result = await controller.Update(projectId, noteId, noteViewModel);

            TestHelper.AssertActionResult<PartialViewResult, NoteFormViewModel>
            (
                result,
                NotesView.NoteFormPartial
            );
        }

        [Fact]
        public async Task Update_InvalidNoteId_ShouldReturnJsonError()
        {
            var projectId = 1;
            var noteId = 1;
            notesRepoMock.Setup(r => r.GetNoteByIdAsync(noteId)).ReturnsAsync(null as Note);

            var result = await controller.Update(projectId, noteId, noteViewModel);

            var notFoundResult = Assert.IsType<JsonErrorResult>(result);
        }

        [Fact]
        public async Task Delete_ValidNoteId_ShouldReturnPartialView()
        {
            var projectId = 1;
            var noteId = 99;
            var note = new Note()
            {
                ID = noteId,
                ProjectID = projectId,
                NoteText = "Some note"
            };
            var notes = new List<Note>()
            {
                new Note()
                {
                    ID = 98,
                    ProjectID = projectId,
                    NoteText = "Some other note"
                }
            };
            notesRepoMock.Setup(r => r.GetNoteByIdAsync(noteId))
                .ReturnsAsync(note);
            notesRepoMock.Setup(r => r.SaveAllAsync())
                .ReturnsAsync(true);
            notesRepoMock.Setup(r => r.GetNotes(projectId))
                .Returns(notes);

            var result = await controller.Delete(projectId, noteId);

            TestHelper.AssertActionResult<PartialViewResult, Collection<NoteFormViewModel>>
            (
                result,
                NotesView.NotesListPartial
            );

        }

        [Fact]
        public async Task Delete_InvalidNoteId_ShouldReturnJsonError()
        {
            var projectId = 1;
            var noteId = 1;
            notesRepoMock.Setup(r => r.GetNoteByIdAsync(noteId)).ReturnsAsync(null as Note);

            var result = await controller.Delete(projectId, noteId);

            var jsonErrorResult = Assert.IsType<JsonErrorResult>(result);
        }

        [Fact]
        public void ConfirmDelete_ValidNoteId_ShouldReturnPartialViewWithConfirmDeleteViewModel()
        {
            var projectId = 1;
            var noteId = 99;


            var result = controller.ConfirmDelete(projectId, noteId);


            var partialViewResult = Assert.IsType<PartialViewResult>(result);
            Assert.NotNull(partialViewResult);

            var viewModel = Assert.IsType<ConfirmDeleteViewModel>(partialViewResult.Model);
            Assert.NotNull(viewModel);

            Assert.Equal(projectId, viewModel.ProjectId);
            Assert.Equal(noteId, viewModel.RecordIdToDelete);
            Assert.Equal(NotesControllerRoute.DeleteNote, viewModel.AjaxDeleteRouteName);
            Assert.Equal("notes-list", viewModel.AjaxUpdateTargetId);
        }
    }
}
