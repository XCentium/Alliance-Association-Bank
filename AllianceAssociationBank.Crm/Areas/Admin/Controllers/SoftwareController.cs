using AllianceAssociationBank.Crm.Areas.Admin.Constants.Software;
using AllianceAssociationBank.Crm.Areas.Admin.ViewModels;
using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
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
    [RoutePrefix("Manage/Software")]
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
                // TODO: test this!
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
    }
}