﻿using AllianceAssociationBank.Crm.Areas.Admin.Constants;
using AllianceAssociationBank.Crm.Areas.Admin.Constants.Reformats;
using AllianceAssociationBank.Crm.Areas.Admin.ViewModels;
using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Areas.Admin.Controllers
{
    [Authorize(Roles = UserRole.Admin)]
    [RouteArea(AreaName.Admin)]
    [RoutePrefix("Manage/Reformats")]
    public class ReformatsController : Controller
    {
        private IReformatRepository _reformatRepository;
        private IMapper _mapper;

        public ReformatsController(IReformatRepository reformatRepository, IMapper mapper)
        {
            _reformatRepository = reformatRepository;
            _mapper = mapper;
        }

        [Route("Index", Name = ReformatsControllerRoute.GetReformats)]
        public async Task<ActionResult> Index()
        {
            var reformatEntities = await _reformatRepository.GetAq2ReformatsAsync();
            var viewModels = _mapper.Map<IEnumerable<ReformatViewModel>>(reformatEntities);

            return PartialView(ReformatView.ReformatListPartial, viewModels);
        }

        [Route("Create", Name = ReformatsControllerRoute.CreateReformat)]
        public ActionResult Create()
        {
            return PartialView(ReformatView.ReformatFormPartial, new ReformatViewModel());
        }

        [Route("Create", Name = ReformatsControllerRoute.CreateReformatHttpPost)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReformatViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return new JsonErrorResult(HttpStatusCode.BadRequest);
            }

            viewModel.TrimValues();

            var existing = await _reformatRepository.GetAq2ReformatByNameAsync(viewModel.ReformatName);
            if (existing != null)
            {
                return new JsonErrorResult(HttpStatusCode.BadRequest, "The reformat record already exists.");
            }

            var reformat = _mapper.Map<Aq2Reformat>(viewModel);
            _reformatRepository.AddAq2Reformat(reformat);
            await _reformatRepository.SaveAllAsync();

            return await Index();
        }

        [Route("Delete/{id}", Name = ReformatsControllerRoute.ConfirmDeleteReformat)]
        public ActionResult ConfirmDelete(int id)
        {
            var viewModel = new ConfirmDeleteViewModel()
            {
                RecordIdToDelete = id,
                AjaxDeleteRouteName = ReformatsControllerRoute.DeleteReformat,
                AjaxUpdateTargetId = HtmlElementIdentifier.ManageValuesContent,
                ConfirmText = "Are you sure you want to delete this record?"
            };

            return PartialView(SharedView.ConfirmDeleteDialogPartial, viewModel);
        }

        // TODO: should we add ValidateAntiForgeryToken?
        [Route("Delete/{id}", Name = ReformatsControllerRoute.DeleteReformat)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var reformat = await _reformatRepository.GetAq2ReformatByIdAsync(id);
            if (reformat == null)
            {
                throw new HttpNotFoundException(DefaultErrorText.Message.FormatForRecordNotFound("reformat", id));
            }

            _reformatRepository.RemoveAq2Reformat(reformat);
            await _reformatRepository.SaveAllAsync();

            return await Index();
        }
    }
}