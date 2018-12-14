using AllianceAssociationBank.Crm.Areas.Admin.Constants;
using AllianceAssociationBank.Crm.Areas.Admin.Constants.Reformats;
using AllianceAssociationBank.Crm.Areas.Admin.Controllers;
using AllianceAssociationBank.Crm.Areas.Admin.ViewModels;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Mappings;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Areas.Admin.Controllers
{
    public class ReformatsControllerTests
    {
        private ReformatsController _controller;

        private IMapper _mapper;
        private Mock<IReformatRepository> _mockReformatRepository;
        private List<Aq2Reformat> _reformats;

        public ReformatsControllerTests()
        {
            _mockReformatRepository = new Mock<IReformatRepository>();
            _mapper = CrmAutoMapperProfile.GetMapper();

            _controller = new ReformatsController(_mockReformatRepository.Object, _mapper);

            _reformats = new List<Aq2Reformat>()
            {
                new Aq2Reformat() { ID = 1, ReformatName = "Reformat 1" },
                new Aq2Reformat() { ID = 2, ReformatName = "Reformat 2" }
            };
        } 

        [Fact]
        public async Task Index_ActionResult_ShouldReturnAq2ReformatListPartialView()
        {
            _mockReformatRepository.Setup(r => r.GetReformatsAsync()).ReturnsAsync(_reformats);

            var result = await _controller.Index();

            AssertHelper.AssertActionResult<PartialViewResult, List<ReformatViewModel>>(
                result,
                ReformatView.ReformatListPartial);
        }


        [Fact]
        public void Create_NewReformatForm_ShouldReturnReformatFormPartialView()
        {
            var result = _controller.Create();

            AssertHelper.AssertActionResult<PartialViewResult, ReformatViewModel>(
                result,
                ReformatView.ReformatFormPartial);
        }

        [Fact]
        public async Task Create_NewReformatEntity_ShouldReturnReformatListPartialView()
        {
            var reformat = new ReformatViewModel()
            {
                ReformatName = "New Reformat"
            };
            _mockReformatRepository.Setup(r => r.SaveAllAsync()).ReturnsAsync(true);

            var result = await _controller.Create(reformat);

            AssertHelper.AssertActionResult<PartialViewResult, List<ReformatViewModel>>(
                result,
                ReformatView.ReformatListPartial);
        }

        [Fact]
        public async Task Create_InvalidReformatViewModel_ShouldReturnJsonErrorResult()
        {
            _controller.ModelState.AddModelError("ReformatName", "The Reformat Name field is required.");
            var newReformat = new ReformatViewModel()
            {
                ReformatName = null
            };

            var result = await _controller.Create(newReformat);

            var jsonError = Assert.IsType<JsonErrorResult>(result);
        }

        [Fact]
        public async Task Create_DuplicateReformatEntity_ShouldReturnJsonErrorResult()
        {
            var existingReformat = _reformats.First();
            var duplicateReformat = new ReformatViewModel()
            {
                ReformatName = existingReformat.ReformatName,
            };
            _mockReformatRepository
                .Setup(r => r.GetReformatByNameAsync(existingReformat.ReformatName))
                .ReturnsAsync(existingReformat);

            var result = await _controller.Create(duplicateReformat);

            var jsonError = Assert.IsType<JsonErrorResult>(result);
        }

        [Fact]
        public void ConfirmDelete_ValidReformatId_ShouldReturnPartialViewWithConfirmDeleteViewModel()
        {
            var reformatId = _reformats.First().ID;

            var result = _controller.ConfirmDelete(reformatId);

            var viewModel = AssertHelper.AssertActionResult<PartialViewResult, ConfirmDeleteViewModel>(result);
            Assert.Equal(reformatId, viewModel.RecordIdToDelete);
            Assert.Equal(ReformatsControllerRoute.DeleteReformat, viewModel.AjaxDeleteRouteName);
            Assert.Equal(HtmlElementIdentifier.ManageValuesContent, viewModel.AjaxUpdateTargetId);
        }

        [Fact]
        public async Task Delete_ExistingReformatEntity_ShouldReturnReformatListPartialView()
        {
            var reformat = _reformats.First();
            var reformatId = reformat.ID;

            _mockReformatRepository
                .Setup(r => r.GetReformatByIdAsync(reformatId))
                .ReturnsAsync(reformat);
            _mockReformatRepository
                .Setup(r => r.SaveAllAsync())
                .ReturnsAsync(true);
            _mockReformatRepository
                .Setup(r => r.GetReformatsAsync())
                .ReturnsAsync(_reformats);

            var result = await _controller.Delete(reformatId);

            AssertHelper.AssertActionResult<PartialViewResult, List<ReformatViewModel>>(
                result,
                ReformatView.ReformatListPartial);
        }

        [Fact]
        public async Task Delete_NonExistingReformatEntity_ShouldThrowHttpNotFoundException()
        {
            var reformatId = 999;

            _mockReformatRepository
                .Setup(r => r.GetReformatByIdAsync(reformatId))
                .ReturnsAsync((Aq2Reformat)null);

            var result = await Record.ExceptionAsync(() => _controller.Delete(reformatId));

            Assert.IsType<HttpNotFoundException>(result);
        }
    }
}
