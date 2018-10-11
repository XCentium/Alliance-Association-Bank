using AllianceAssociationBank.Crm.Constants.CheckScanners;
using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Mappings;
using AllianceAssociationBank.Crm.Tests.Helpers;
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
            //var response = new Mock<HttpResponseBase>();
            //var httpContext = new Mock<HttpContextBase>();
            //httpContext.SetupGet(c => c.Response).Returns(response.Object);
            //controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);

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
                ProjectID = scanner.ProjectID ?? 0,
                Model = scanner.Model,
                System = scanner.System
            };
        }

        [Fact]
        public void Index_ValidProjectId_ScannersListPartialView()
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

            TestHelper.AssertActionResult<PartialViewResult, Collection<ScannerFormViewModel>>
            (
                result, 
                CheckScannersView.ScannersListPartial,
                scanners.Count
            );
        }

        [Fact]
        public void Index_InvalidProjectId_ScannersListPartialViewWithZeroRecords()
        {
            var projectId = 99;

            var result = controller.Index(projectId);

            TestHelper.AssertActionResult<PartialViewResult, Collection<ScannerFormViewModel>>
            (
                result, 
                CheckScannersView.ScannersListPartial,
                0
            );
        }

        [Fact]
        public void Create_NewScannerForm_ScannerFormPartialView()
        {
            var projectId = 99;

            var result = controller.Create(projectId);

            TestHelper.AssertActionResult<PartialViewResult, ScannerFormViewModel>
            (
                result,
                CheckScannersView.ScannerFormPartial
            );
        }

        [Fact]
        public async Task Create_CreateNewScanner_ScannersListPartialView()
        {
            var projectId = 99;
            scannerViewModel.ID = 0; // On create Id should be 0
            scannerViewModel.ProjectID = projectId;
            checkScannerRepoMock.Setup(r => r.SaveAllAsync()).ReturnsAsync(true);

            var result = await controller.Create(projectId, scannerViewModel);

            TestHelper.AssertActionResult<PartialViewResult, Collection<ScannerFormViewModel>>
            (
                result,
                CheckScannersView.ScannersListPartial
            );
        }

        [Fact]
        public async Task Edit_ValidScannerId_ScannerFormPartialView()
        {
            var scannerId = scanner.ID;
            checkScannerRepoMock.Setup(r => r.GetScannerByIdAsync(scannerId)).ReturnsAsync(scanner);

            var result = await controller.Edit(99, scannerId);

            TestHelper.AssertActionResult<PartialViewResult, ScannerFormViewModel>
            (
                result,
                CheckScannersView.ScannerFormPartial
            );
        }
    }
}
