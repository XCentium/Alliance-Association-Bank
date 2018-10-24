using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Notes;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Filters;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    [RoutePrefix("Projects/{projectId}/Notes")]
    [RedirectOnInvalidAjaxRequest]
    public class NotesController : Controller
    {
        private INoteRepository _notesRepository;
        private IMapper _mapper;

        public NotesController(INoteRepository notesRepository, IMapper mapper)
        {
            _notesRepository = notesRepository;
            _mapper = mapper;
        }

        [Route("Index", Name = NotesControllerRoute.GetNotes)]
        public ActionResult Index(int projectId)
        {
            var notes = _notesRepository.GetNotes(projectId);

            return PartialView(NotesView.NotesListPartial, _mapper.Map<Collection<NoteFormViewModel>>(notes));
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [Route("Create", Name = NotesControllerRoute.CreateNote)]
        public ActionResult Create(int projectId)
        {
            if (projectId == 0)
            {
                return new JsonErrorResult(HttpStatusCode.BadRequest, DefaultErrorText.Message.CreateProjectFirst);
            }

            var viewModel = new NoteFormViewModel();
            viewModel.ProjectID = projectId;

            return PartialView(NotesView.NoteFormPartial, viewModel);
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [Route("Create", Name = NotesControllerRoute.CreateNoteHttpPost)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int projectId, NoteFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView(NotesView.NoteFormPartial, viewModel);
            }

            var note = _mapper.Map<Note>(viewModel);

            note.SetDefaultsOnCreate();

            _notesRepository.AddNote(note);
            await _notesRepository.SaveAllAsync();

            return Index(projectId);
        }

        [Route("Edit/{id}", Name = NotesControllerRoute.EditNote)]
        public async Task<ActionResult> Edit(int projectId, int id)
        {
            var note = await _notesRepository.GetNoteByIdAsync(id);

            if (note == null)
            {
                throw new HttpNotFoundException(DefaultErrorText.Message.FormatForRecordNotFound("note", id));
            }

            var viewModel = _mapper.Map<NoteFormViewModel>(note);

            return PartialView(NotesView.NoteFormPartial, viewModel);
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [Route("Update/{id}", Name = NotesControllerRoute.UpdateNote)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int projectId, int id, NoteFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView(NotesView.NoteFormPartial, viewModel);
            }

            var note = await _notesRepository.GetNoteByIdAsync(id);
            if (note == null)
            {
                throw new HttpNotFoundException(DefaultErrorText.Message.FormatForRecordNotFound("note", id));
            }

            _mapper.Map(viewModel, note);
            await _notesRepository.SaveAllAsync();

            return Index(projectId);
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [Route("Delete/{id}", Name = NotesControllerRoute.ConfirmDeleteNote)]
        public ActionResult ConfirmDelete(int projectId, int id)
        {
            var model = new ConfirmDeleteViewModel()
            {
                ProjectId = projectId,
                RecordIdToDelete = id,
                AjaxDeleteRouteName = NotesControllerRoute.DeleteNote,
                AjaxUpdateTargetId = "notes-list",
                ConfirmText = "Are you sure you want to delete this note?"
            };

            return PartialView(SharedView.ConfirmDeleteDialogPartial, model);
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [Route("Delete/{id}", Name = NotesControllerRoute.DeleteNote)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int projectId, int id)
        {
            var note = await _notesRepository.GetNoteByIdAsync(id);
            if (note == null)
            {
                throw new HttpNotFoundException(DefaultErrorText.Message.FormatForRecordNotFound("note", id));
            }

            _notesRepository.RemoveNote(note);
            await _notesRepository.SaveAllAsync();

            return Index(projectId);
        }
    }
}