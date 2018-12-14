using AllianceAssociationBank.Crm.Areas.Admin.Constants;
using AllianceAssociationBank.Crm.Areas.Admin.Constants.Manage;
using AllianceAssociationBank.Crm.Areas.Admin.Constants.Reformats;
using AllianceAssociationBank.Crm.Areas.Admin.ViewModels;
using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Filters;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.SessionState;

namespace AllianceAssociationBank.Crm.Areas.Admin.Controllers
{
    [Authorize(Roles = UserRole.Admin)]
    [RouteArea(AreaName.Admin)]
    [RoutePrefix("Manage/Reformats")]
    [RedirectOnInvalidAjaxRequest(ControllerName.Manage, ManageControllerAction.Index)]
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
            var reformatEntities = await _reformatRepository.GetReformatsAsync();
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

            var existing = await _reformatRepository.GetReformatByNameAsync(viewModel.ReformatName);
            if (existing != null)
            {
                return new JsonErrorResult(HttpStatusCode.BadRequest, "The reformat record already exists.");
            }

            var reformat = _mapper.Map<Aq2Reformat>(viewModel);
            _reformatRepository.AddReformat(reformat);
            await _reformatRepository.SaveAllAsync();

            return await Index();
        }

        [Route("Delete/{id}", Name = ReformatsControllerRoute.ConfirmDeleteReformat)]
        public async Task<ActionResult> ConfirmDelete(int id)
        {
            var countOfAssociatedProjects = await _reformatRepository.GetCountOfAssociatedActiveProjects(id);

            var viewModel = new ConfirmDeleteViewModel()
            {
                RecordIdToDelete = id,
                AjaxDeleteRouteName = ReformatsControllerRoute.DeleteReformat,
                AjaxUpdateTargetId = HtmlElementIdentifier.ManageValuesContent,
                ConfirmText = GetDeleteConfirmText(countOfAssociatedProjects)
            };

            return PartialView(SharedView.ConfirmDeleteDialogPartial, viewModel);
        }

        // TODO: should we add ValidateAntiForgeryToken?
        [Route("Delete/{id}", Name = ReformatsControllerRoute.DeleteReformat)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var reformat = await _reformatRepository.GetReformatByIdAsync(id);
            if (reformat == null)
            {
                throw new HttpNotFoundException(DefaultErrorText.Message.FormatForRecordNotFound("reformat", id));
            }

            _reformatRepository.RemoveReformat(reformat);
            await _reformatRepository.SaveAllAsync();

            return await Index();
        }

        private string GetDeleteConfirmText(int countOfAssociatedProjects)
        {
            const string AreYouSureText = "Are you sure you want to delete this record?";

            string associatedRecordsText;
            if (countOfAssociatedProjects < 1)
            {
                associatedRecordsText = "No active projects associated with this record.";
            }
            else if (countOfAssociatedProjects == 1)
            {
                associatedRecordsText = "1 active project associated with this record.";
            }
            else
            {
                associatedRecordsText = $"{countOfAssociatedProjects} active projects associated with this record.";
            }

            return $"{associatedRecordsText} {AreYouSureText}";
        }
    }
}