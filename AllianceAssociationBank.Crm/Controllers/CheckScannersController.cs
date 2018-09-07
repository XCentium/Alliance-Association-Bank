using AllianceAssociationBank.Crm.Constants.CheckScanners;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
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
            var viewModel = new ScannerFormViewModel();
            viewModel.ProjectID = projectId;

            return PartialView(CheckScannersView.ScannerFormPartial, viewModel);
        }


        [Route("Create", Name = CheckScannersControllerRoute.CreateScannerHttpPost)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int projectId, ScannerFormViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView(CheckScannersView.ScannerFormPartial, viewModel);
                }

                var scanner = _mapper.Map<CheckScanner>(viewModel);
                _scannerRepository.AddScanner(scanner);
                await _scannerRepository.SaveAllAsync();

                return Index(projectId);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [Route("Edit/{id}", Name = CheckScannersControllerRoute.EditScanner)]
        public async Task<ActionResult> Edit(int projectId, int id)
        {
            try
            {
                var scanner = await _scannerRepository.GetScannerByIdAsync(id);

                if (scanner == null)
                {
                    return HttpNotFound();
                }

                var viewModel = _mapper.Map<ScannerFormViewModel>(scanner);

                return PartialView(CheckScannersView.ScannerFormPartial, viewModel);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [Route("Update/{id}", Name = CheckScannersControllerRoute.UpdateScanner)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int projectId, int id, ScannerFormViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView(CheckScannersView.ScannerFormPartial, viewModel);
                }

                var scanner = await _scannerRepository.GetScannerByIdAsync(id);
                if (scanner == null)
                {
                    return HttpNotFound();
                }

                _mapper.Map(viewModel, scanner);
                await _scannerRepository.SaveAllAsync();

                return Index(projectId);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [Route("Delete/{id}", Name = CheckScannersControllerRoute.DeleteScanner)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int projectId, int id)
        {
            try
            {
                var scanner = await _scannerRepository.GetScannerByIdAsync(id);
                if (scanner == null)
                {
                    return HttpNotFound();
                }

                _scannerRepository.RemoveScanner(scanner);
                await _scannerRepository.SaveAllAsync();

                return Index(projectId);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError); ;
            }
        }
    }
}