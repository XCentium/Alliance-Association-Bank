using AllianceAssociationBank.Crm.Constants.CheckScanners;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    [RoutePrefix("Projects/{projectId}/Scanners")]
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

            return PartialView(CheckScannersView.ScannersListPartial, _mapper.Map<List<ScannerFormViewModel>>(scanners));
        }

        [Route("Create", Name = CheckScannersControllerRoute.CreateScanner)]
        public ActionResult Create(int projectId)
        {
            var model = new ScannerFormViewModel();
            model.ProjectID = projectId;

            return PartialView(CheckScannersView.ScannerFormPartial, model);
        }

        [Route("Update/{id}", Name = CheckScannersControllerRoute.EditScanner)]
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var scanner = await _scannerRepository.GetScannerByIdAsync(id);

                if (scanner == null)
                {
                    return HttpNotFound();
                }

                var model = _mapper.Map<ScannerFormViewModel>(scanner);

                return PartialView(CheckScannersView.ScannerFormPartial, model);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}