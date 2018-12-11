using AllianceAssociationBank.Crm.Areas.Admin.Constants.Software;
using AllianceAssociationBank.Crm.Areas.Admin.Controllers;
using AllianceAssociationBank.Crm.Areas.Admin.ViewModels;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Mappings;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Areas.Admin.Controllers
{
    public class SoftwareControllerTests
    {
        private SoftwareController _controller;

        private IMapper _mapper;
        private Mock<ISoftwareRepository> _mockSoftwareRepository;
        private List<Software> _softwareList;

        public SoftwareControllerTests()
        {
            _mockSoftwareRepository = new Mock<ISoftwareRepository>();
            _mapper = CrmAutoMapperProfile.GetMapper();

            _controller = new SoftwareController(_mockSoftwareRepository.Object, _mapper);

            _softwareList = new List<Software>()
            {
                new Software() { ID = 1, SoftwareName = "Software 1" },
                new Software() { ID = 2, SoftwareName = "Software 2" }
            };
        } 

        [Fact]
        public async Task Index_ActionResult_ShouldReturnSoftwareListPartialView()
        {
            _mockSoftwareRepository.Setup(r => r.GetSoftwareAsync()).ReturnsAsync(_softwareList);

            var result = await _controller.Index();

            AssertHelper.AssertActionResult<PartialViewResult, List<SoftwareViewModel>>(
                result,
                SoftwareView.SoftwareListPartial);
        }


        [Fact]
        public void Create_NewSoftwareForm_ShouldReturnSoftwareFormPartialView()
        {
            var result = _controller.Create();

            AssertHelper.AssertActionResult<PartialViewResult, SoftwareViewModel>(
                result,
                SoftwareView.SoftwareFormPartial);
        }

        [Fact]
        public async Task Create_NewSoftwareEntity_ShouldReturnSoftwareListPartialView()
        {
            var software = new SoftwareViewModel()
            {
                SoftwareName = "New Software"
            };
            _mockSoftwareRepository.Setup(r => r.SaveAllAsync()).ReturnsAsync(true);

            var result = await _controller.Create(software);

            AssertHelper.AssertActionResult<PartialViewResult, List<SoftwareViewModel>>(
                result,
                SoftwareView.SoftwareListPartial);
        }

        [Fact]
        public async Task Create_InvalidSoftwareViewModel_ShouldReturnJsonErrorResult()
        {
            _controller.ModelState.AddModelError("SoftwareName", "The Software Name field is required.");
            var newSoftware = new SoftwareViewModel()
            {
                SoftwareName = null
            };

            var result = await _controller.Create(newSoftware);

            var jsonError = Assert.IsType<JsonErrorResult>(result);
        }

        [Fact]
        public async Task Create_DuplicateSoftwareEntity_ShouldReturnJsonErrorResult()
        {
            var existingSoftware = _softwareList.First();
            var duplicateSoftware = new SoftwareViewModel()
            {
                SoftwareName = existingSoftware.SoftwareName,
            };
            _mockSoftwareRepository
                .Setup(r => r.GetSoftwareByNameAsync(existingSoftware.SoftwareName))
                .ReturnsAsync(existingSoftware);

            var result = await _controller.Create(duplicateSoftware);

            var jsonError = Assert.IsType<JsonErrorResult>(result);
        }

        [Fact]
        public async Task Delete_ExistingSoftwareEntity_ShouldReturnSoftwareListPartialView()
        {
            var software = _softwareList.First();
            var softwareId = software.ID;

            _mockSoftwareRepository
                .Setup(r => r.GetSoftwareByIdAsync(softwareId))
                .ReturnsAsync(software);
            _mockSoftwareRepository
                .Setup(r => r.SaveAllAsync())
                .ReturnsAsync(true);
            _mockSoftwareRepository
                .Setup(r => r.GetSoftwareAsync())
                .ReturnsAsync(_softwareList);

            var result = await _controller.Delete(softwareId);

            AssertHelper.AssertActionResult<PartialViewResult, List<SoftwareViewModel>>(
                result,
                SoftwareView.SoftwareListPartial);
        }

        [Fact]
        public async Task Delete_NonExistingSoftwareEntity_ShouldThrowHttpNotFoundException()
        {
            var softwareId = 999;

            _mockSoftwareRepository
                .Setup(r => r.GetSoftwareByIdAsync(softwareId))
                .ReturnsAsync((Software)null);

            var result = await Record.ExceptionAsync(() => _controller.Delete(softwareId));

            Assert.IsType<HttpNotFoundException>(result);
        }
    }
}
