﻿using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Notes;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
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

        [Authorize(Roles = UserRoleName.ReadWriteUser)]
        [Route("Create", Name = NotesControllerRoute.CreateNote)]
        public ActionResult Create(int projectId)
        {
            // TODO: if projectId is null need to show an error, but better way to do this
            if (projectId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = new NoteFormViewModel();
            viewModel.ProjectID = projectId;

            return PartialView(NotesView.NoteFormPartial, viewModel);
        }

        [Authorize(Roles = UserRoleName.ReadWriteUser)]
        [Route("Create", Name = NotesControllerRoute.CreateNoteHttpPost)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int projectId, NoteFormViewModel viewModel)
        {
            try
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
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [Route("Edit/{id}", Name = NotesControllerRoute.EditNote)]
        public async Task<ActionResult> Edit(int projectId, int id)
        {
            try
            {
                var note = await _notesRepository.GetNoteByIdAsync(id);

                if (note == null)
                {
                    return HttpNotFound();
                }

                var viewModel = _mapper.Map<NoteFormViewModel>(note);

                return PartialView(NotesView.NoteFormPartial, viewModel);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = UserRoleName.ReadWriteUser)]
        [Route("Update/{id}", Name = NotesControllerRoute.UpdateNote)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int projectId, int id, NoteFormViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView(NotesView.NoteFormPartial, viewModel);
                }

                var note = await _notesRepository.GetNoteByIdAsync(id);
                if (note == null)
                {
                    return HttpNotFound();
                }

                _mapper.Map(viewModel, note);
                await _notesRepository.SaveAllAsync();

                return Index(projectId);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [Authorize(Roles = UserRoleName.ReadWriteUser)]
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

        [Authorize(Roles = UserRoleName.ReadWriteUser)]
        [Route("Delete/{id}", Name = NotesControllerRoute.DeleteNote)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int projectId, int id)
        {
            try
            {
                var note = await _notesRepository.GetNoteByIdAsync(id);
                if (note == null)
                {
                    return HttpNotFound();
                }

                _notesRepository.RemoveNote(note);
                await _notesRepository.SaveAllAsync();

                return Index(projectId);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}