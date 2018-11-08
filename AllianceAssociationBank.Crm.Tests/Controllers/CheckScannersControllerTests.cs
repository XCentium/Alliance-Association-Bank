using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.CheckScanners;
using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Mappings;
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
    public class CheckScannersControllerTests
    {
        private CheckScannersController controller;
        private IMapper mapper;

        private Mock<ICheckScannerRepository> checkScannerRepoMock;

        private ScannerFormViewModel scannerViewModel;
        private CheckScanner scanner;

        public CheckScannersControllerTests()
        {
            checkScannerRepoMock = new Mock<ICheckScannerRepository>();
            mapper = CrmAutoMapperProfile.GetMapper();

            controller = new CheckScannersController(checkScannerRepoMock.Object, mapper);
            // Mock http context so http response object is not null
            var response = new Mock<HttpResponseBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Response).Returns(response.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);

            scanner = new CheckScanner()
            {
                ID = 1001,
                ProjectID = 101,
                Model = "Model 1",
                System = "AQ2"
            };

            scannerViewModel = new ScannerFormViewModel()
            {
                ID = scanner.ID,
                ProjectID = scanner.ProjectID,
                Model = scanner.Model,
                System = scanner.System
            };
        }

        [Fact]
        public void Index_ValidProjectId_ShouldReturnPartialView()
        {
            var scanners = new List<CheckScanner>()
            {
                new CheckScanner()
                {
                    ID = 1002,
                    Model = "Model 1",
                    System = "AQ2"
                },
                new CheckScanner()
                {
                    ID = 1003,
                    Model = "Model 2",
                    System = "AQ2"
                }
            };
            var projectId = 99;
            checkScannerRepoMock.Setup(r => r.GetScanners(projectId)).Returns(scanners);

            var result = controller.Index(projectId);

            AssertHelper.AssertActionResult<PartialViewResult, Collection<ScannerFormViewModel>>
            (
                result, 
                CheckScannersView.ScannersListPartial,
                scanners.Count
            );
        }

        [Fact]
        public void Index_InvalidProjectId_ShouldReturnPartialViewWithZeroRecords()
        {
            var projectId = 99;

            var result = controller.Index(projectId);

            AssertHelper.AssertActionResult<PartialViewResult, Collection<ScannerFormViewModel>>
            (
                result, 
                CheckScannersView.ScannersListPartial,
                0
            );
        }

        [Fact]
        public void Create_NewScannerEntry_ShouldReturnPartialView()
        {
            var projectId = 99;

            var result = controller.Create(projectId);

            AssertHelper.AssertActionResult<PartialViewResult, ScannerFormViewModel>
            (
                result,
                CheckScannersView.ScannerFormPartial
            );
        }

        [Fact]
        public async Task Create_ValidInputModel_ShouldReturnPartialView()
        {
            var projectId = 99;
            scannerViewModel.ID = 0; // On create Id should be 0
            scannerViewModel.ProjectID = projectId;
            checkScannerRepoMock.Setup(r => r.SaveAllAsync()).ReturnsAsync(true);

            var result = await controller.Create(projectId, scannerViewModel);

            AssertHelper.AssertActionResult<PartialViewResult, Collection<ScannerFormViewModel>>
            (
                result,
                CheckScannersView.ScannersListPartial
            );
        }

        [Fact]
        public async Task Edit_ValidScannerId_ShouldReturnPartialView()
        {
            var scannerId = scanner.ID;
            checkScannerRepoMock.Setup(r => r.GetScannerByIdAsync(scannerId)).ReturnsAsync(scanner);

            var result = await controller.Edit(99, scannerId);

            AssertHelper.AssertActionResult<PartialViewResult, ScannerFormViewModel>
            (
                result,
                CheckScannersView.ScannerFormPartial
            );
        }

        [Fact]
        public async Task Edit_InvalidScannerId_ShouldThrowHttpNotFoundException()
        {
            var scannerId = 1;
            checkScannerRepoMock.Setup(r => r.GetScannerByIdAsync(scannerId)).ReturnsAsync(null as CheckScanner);

            var exception = await Record.ExceptionAsync(() => controller.Edit(99, scannerId));

            Assert.IsType<HttpNotFoundException>(exception);
            Assert.NotNull(exception);
        }

        [Fact]
        public async Task Update_ValidInputModel_ShouldReturnPartialView()
        {
            var projectId = scannerViewModel.ProjectID;
            var scannerId = scannerViewModel.ID;
            scannerViewModel.Model = "Updated model";
            checkScannerRepoMock.Setup(r => r.GetScannerByIdAsync(scannerId)).ReturnsAsync(scanner);
            checkScannerRepoMock.Setup(r => r.SaveAllAsync()).ReturnsAsync(true);

            var result = await controller.Update(projectId, scannerId, scannerViewModel);

            AssertHelper.AssertActionResult<PartialViewResult, Collection<ScannerFormViewModel>>
            (
                result,
                CheckScannersView.ScannersListPartial
            );
        }

        [Fact]
        public async Task Update_InvalidInputModel_ShouldReturnPartialViewWithBadRequestStatusCode()
        {
            var projectId = scannerViewModel.ProjectID;
            var scannerId = scannerViewModel.ID;
            scannerViewModel.Model = null;
            controller.ModelState.AddModelError("Model", "The Model field is required.");

            var result = await controller.Update(projectId, scannerId, scannerViewModel);

            AssertHelper.AssertActionResult<PartialViewResult, ScannerFormViewModel>
            (
                result,
                CheckScannersView.ScannerFormPartial
            );
        }

        [Fact]
        public async Task Update_InvalidScannerId_ShouldThrowHttpNotFoundException()
        {
            var projectId = 1;
            var scannerId = 1;
            checkScannerRepoMock.Setup(r => r.GetScannerByIdAsync(scannerId)).ReturnsAsync(null as CheckScanner);

            var exception = await Record.ExceptionAsync(() => controller.Update(projectId, scannerId, scannerViewModel));

            Assert.IsType<HttpNotFoundException>(exception);
            Assert.NotNull(exception);
        }

        [Fact]
        public async Task Delete_ValidScannnerId_ShouldReturnPartialView()
        {
            var projectId = 1;
            var scannerId = 99;
            var scanner = new CheckScanner()
            {
                ID = scannerId,
                ProjectID = projectId,
                Model = "Model 2",
                System = "AQ2"
            };
            var scanners = new List<CheckScanner>()
            {
                new CheckScanner()
                {
                    ID = 98,
                    ProjectID = projectId,
                    Model = "Model 1",
                    System = "AQ2"
                }
            };
            checkScannerRepoMock.Setup(r => r.GetScannerByIdAsync(scannerId))
                .ReturnsAsync(scanner);
            checkScannerRepoMock.Setup(r => r.SaveAllAsync())
                .ReturnsAsync(true);
            checkScannerRepoMock.Setup(r => r.GetScanners(projectId))
                .Returns(scanners);

            var result = await controller.Delete(projectId, scannerId);

            AssertHelper.AssertActionResult<PartialViewResult, Collection<ScannerFormViewModel>>
            (
                result,
                CheckScannersView.ScannersListPartial
            );

        }

        [Fact]
        public async Task Delete_InvalidScannerId_ShouldThrowHttpNotFoundException()
        {
            var projectId = 1;
            var scannerId = 1;
            checkScannerRepoMock.Setup(r => r.GetScannerByIdAsync(scannerId)).ReturnsAsync(null as CheckScanner);

            var exception = await Record.ExceptionAsync(() => controller.Delete(projectId, scannerId));

            Assert.IsType<HttpNotFoundException>(exception);
            Assert.NotNull(exception);
        }

        [Fact]
        public void ConfirmDelete_ValidScannerId_ShouldReturnPartialViewWithConfirmDeleteViewModel()
        {
            var projectId = 1;
            var scannerId = 99;


            var result = controller.ConfirmDelete(projectId, scannerId);


            var partialViewResult = Assert.IsType<PartialViewResult>(result);
            Assert.NotNull(partialViewResult);

            var viewModel = Assert.IsType<ConfirmDeleteViewModel>(partialViewResult.Model);
            Assert.NotNull(viewModel);

            Assert.Equal(projectId, viewModel.ProjectId);
            Assert.Equal(scannerId, viewModel.RecordIdToDelete);
            Assert.Equal(CheckScannersControllerRoute.DeleteScanner, viewModel.AjaxDeleteRouteName);
            Assert.Equal("check-scanners-list", viewModel.AjaxUpdateTargetId);
        }
    }
}
