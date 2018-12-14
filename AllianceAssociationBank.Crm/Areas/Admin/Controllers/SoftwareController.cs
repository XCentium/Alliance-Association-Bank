using AllianceAssociationBank.Crm.Areas.Admin.Constants;
using AllianceAssociationBank.Crm.Areas.Admin.Constants.Manage;
using AllianceAssociationBank.Crm.Areas.Admin.Constants.Software;
using AllianceAssociationBank.Crm.Areas.Admin.ViewModels;
using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Filters;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace AllianceAssociationBank.Crm.Areas.Admin.Controllers
{
    [Authorize(Roles = UserRole.Admin)]
    [RouteArea(AreaName.Admin)]
    [RoutePrefix("Manage/Software")]
    [RedirectOnInvalidAjaxRequest(ControllerName.Manage, ManageControllerAction.Index)]
    public class SoftwareController : Controller
    {
        private ISoftwareRepository _softwareRepository;
        private IMapper _mapper;

        public SoftwareController(ISoftwareRepository softwareRepository, IMapper mapper)
        {
            _softwareRepository = softwareRepository;
            _mapper = mapper;
        }

        [Route("Index", Name = SoftwareControllerRoute.GetSoftwareList)]
        public async Task<ActionResult> Index()
        {
            var softwareEntities = await _softwareRepository.GetSoftwareAsync();
            var viewModels = _mapper.Map<IEnumerable<SoftwareViewModel>>(softwareEntities);

            return PartialView(SoftwareView.SoftwareListPartial, viewModels);
        }

        [Route("Create", Name = SoftwareControllerRoute.CreateSoftware)]
        public ActionResult Create()
        {
            return PartialView(SoftwareView.SoftwareFormPartial, new SoftwareViewModel());
        }

        [Route("Create", Name = SoftwareControllerRoute.CreateSoftwareHttpPost)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SoftwareViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return new JsonErrorResult(HttpStatusCode.BadRequest);
            }

            viewModel.TrimValues();

            var existing = await _softwareRepository.GetSoftwareByNameAsync(viewModel.SoftwareName);
            if (existing != null)
            {
                return new JsonErrorResult(HttpStatusCode.BadRequest, "The software record already exists.");
            }

            var employee = _mapper.Map<Software>(viewModel);
            _softwareRepository.AddSoftware(employee);
            await _softwareRepository.SaveAllAsync();

            return await Index();
        }

        [Route("Delete/{id}", Name = SoftwareControllerRoute.ConfirmDeleteSoftware)]
        public async Task<ActionResult> ConfirmDelete(int id)
        {
            var countOfAssociatedProjects = await _softwareRepository.GetCountOfAssociatedActiveProjects(id);

            var viewModel = new ConfirmDeleteViewModel()
            {
                RecordIdToDelete = id,
                AjaxDeleteRouteName = SoftwareControllerRoute.DeleteSoftware,
                AjaxUpdateTargetId = HtmlElementIdentifier.ManageValuesContent,
                ConfirmText = GetDeleteConfirmText(countOfAssociatedProjects)
            };

            return PartialView(SharedView.ConfirmDeleteDialogPartial, viewModel);
        }

        // TODO: should we add ValidateAntiForgeryToken?
        [Route("Delete/{id}", Name = SoftwareControllerRoute.DeleteSoftware)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var software = await _softwareRepository.GetSoftwareByIdAsync(id);
            if (software == null)
            {
                throw new HttpNotFoundException(DefaultErrorText.Message.FormatForRecordNotFound("software", id));
            }

            _softwareRepository.RemoveSoftware(software);
            await _softwareRepository.SaveAllAsync();

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