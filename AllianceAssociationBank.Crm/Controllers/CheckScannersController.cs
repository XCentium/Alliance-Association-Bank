using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.CheckScanners;
using AllianceAssociationBank.Crm.Constants.Projects;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Filters;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.SessionState;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    [RoutePrefix("Projects/{projectId}/Scanners")]
    [RedirectOnInvalidAjaxRequest(ControllerName.Projects, ProjectsControllerAction.Edit, "projectId")]
    public class CheckScannersController : Controller
    {
        private ICheckScannerRepository _scannerRepository;
        private IMapper _mapper;

        public CheckScannersController(ICheckScannerRepository scannerRepository, IMapper mapper)
        {
            _scannerRepository = scannerRepository;
            _mapper = mapper;
        }

        [Route("Index", Name = CheckScannersControllerRoute.GetScanners)]
        public ActionResult Index(int projectId)
        {
            var scanners = _scannerRepository.GetScanners(projectId);

            return PartialView(CheckScannersView.ScannersListPartial, _mapper.Map<Collection<ScannerFormViewModel>>(scanners));
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [Route("Create", Name = CheckScannersControllerRoute.CreateScanner)]
        public ActionResult Create(int projectId)
        {
            if (projectId == 0)
            {
                return new JsonErrorResult(HttpStatusCode.BadRequest, DefaultErrorText.Message.CreateProjectFirst);
            }

            var viewModel = new ScannerFormViewModel();
            viewModel.ProjectID = projectId;

            return PartialView(CheckScannersView.ScannerFormPartial, viewModel);
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [Route("Create", Name = CheckScannersControllerRoute.CreateScannerHttpPost)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int projectId, ScannerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return new JsonErrorResult(HttpStatusCode.BadRequest);
            }

            var scanner = _mapper.Map<CheckScanner>(viewModel);
            _scannerRepository.AddScanner(scanner);
            await _scannerRepository.SaveAllAsync();

            return Index(projectId);
        }

        [Route("Edit/{id}", Name = CheckScannersControllerRoute.EditScanner)]
        public async Task<ActionResult> Edit(int projectId, int id)
        {
            var scanner = await _scannerRepository.GetScannerByIdAsync(id);

            if (scanner == null)
            {
                throw new HttpNotFoundException(DefaultErrorText.Message.FormatForRecordNotFound("check scanner", id));
            }

            var viewModel = _mapper.Map<ScannerFormViewModel>(scanner);

            return PartialView(CheckScannersView.ScannerFormPartial, viewModel);
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [Route("Update/{id}", Name = CheckScannersControllerRoute.UpdateScanner)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int projectId, int id, ScannerFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return new JsonErrorResult(HttpStatusCode.BadRequest);
            }

            var scanner = await _scannerRepository.GetScannerByIdAsync(id);
            if (scanner == null)
            {
                throw new HttpNotFoundException(DefaultErrorText.Message.FormatForRecordNotFound("check scanner", id));
            }

            _mapper.Map(viewModel, scanner);
            await _scannerRepository.SaveAllAsync();

            return Index(projectId);
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [Route("Delete/{id}", Name = CheckScannersControllerRoute.ConfirmDeleteScanner)]
        public ActionResult ConfirmDelete(int projectId, int id)
        {
            var model = new ConfirmDeleteViewModel()
            {
                ParentId = projectId,
                RecordIdToDelete = id,
                AjaxDeleteRouteName = CheckScannersControllerRoute.DeleteScanner,
                AjaxUpdateTargetId = "check-scanners-list",
                ConfirmText = "Are you sure you want to delete this scanner?"
            };

            return PartialView(SharedView.ConfirmDeleteDialogPartial, model);
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [Route("Delete/{id}", Name = CheckScannersControllerRoute.DeleteScanner)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int projectId, int id)
        {
            var scanner = await _scannerRepository.GetScannerByIdAsync(id);
            if (scanner == null)
            {
                throw new HttpNotFoundException(DefaultErrorText.Message.FormatForRecordNotFound("check scanner", id));
            }

            _scannerRepository.RemoveScanner(scanner);
            await _scannerRepository.SaveAllAsync();

            return Index(projectId);
        }
    }
}