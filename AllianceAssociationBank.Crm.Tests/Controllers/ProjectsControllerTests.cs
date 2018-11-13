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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Controllers
{
    public class ProjectsControllerTests
    {
        private ProjectsController _controller;
        private IMapper _mapper;

        private Mock<IProjectRepository> _projectsRepoMock;
        private Mock<IEmployeeRepository> _employeesRepoMock;
        private Mock<ISoftwareRepository> _softwareRepoMock;
        private Mock<IReformatRepository> _reformatRepoMock;

        private ProjectFormViewModel projectViewModel;
        private Project project;

        public ProjectsControllerTests()
        {
            _projectsRepoMock = new Mock<IProjectRepository>();
            _employeesRepoMock = new Mock<IEmployeeRepository>();
            _softwareRepoMock = new Mock<ISoftwareRepository>();
            _reformatRepoMock = new Mock<IReformatRepository>();
            _mapper = CrmAutoMapperProfile.GetMapper();

            _controller = new ProjectsController(_projectsRepoMock.Object, _employeesRepoMock.Object, _softwareRepoMock.Object, _reformatRepoMock.Object, _mapper);

            projectViewModel = new ProjectFormViewModel()
            {
                ID = 1001,
                ProjectName = "New Project",
                Address = "123 Address",
                City = "Phoenix",
                State = "AZ",
                ZipCode = "12345",
                TIN = "12-3456789",
                Phone = "123-345-6788",
                Institution = "Bank of Nevada",
                OwnerID = 123,
                AFPID = 123,
                BoardingManagerID = 123,
                LockboxCMCID = "12345"
            };

            project = new Project()
            {
                ID = 1001,
                ProjectName = "New Project",
                Address = "123 Address",
                City = "Phoenix",
                State = "AZ",
                ZipCode = "12345",
                TIN = "12-3456789",
                Phone = "123-345-6788",
                Institution = "Bank of Nevada",
                OwnerID = 123,
                AFPID = 123,
                BoardingManagerID = 123,
                LockboxCMCID = "12345"
            };
        }

        [Fact]
        public async Task Create_ValidState_ShouldReturnNotNullResult()
        {
            var result = await _controller.Create();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            var model = Assert.IsType<ProjectFormViewModel>(viewResult.Model);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task Create_ValidModel_ShouldReturnRedirectToRouteResult()
        {
            projectViewModel.ID = 0; // On create Id should be 0
            _projectsRepoMock.Setup(r => r.SaveAllAsync()).ReturnsAsync(true);

            var result = await _controller.Create(projectViewModel);

            Assert.IsType<RedirectToRouteResult>(result);
        }

        [Fact]
        public async Task Create_InvalidModel_ShouldReturnViewResult()
        {
            var inputModel = new ProjectFormViewModel();
            _controller.ModelState.AddModelError("ProjectName", "The Project Name field is required.");

            var result = await _controller.Create(inputModel);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            var model = Assert.IsType<ProjectFormViewModel>(viewResult.Model);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task Edit_ValidProjectId_ShouldReturnViewResult()
        {
            _projectsRepoMock.Setup(r => r.GetProjectByIdAsync(project.ID)).ReturnsAsync(project);

            var result = await _controller.Edit(project.ID);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            var model = Assert.IsType<ProjectFormViewModel>(viewResult.Model);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task Edit_InvalidProjectId_ShouldThrowHttpNotFoundException()
        {
            var projectId = 99;
            _projectsRepoMock.Setup(r => r.GetProjectByIdAsync(projectId)).ReturnsAsync(null as Project);

            var exception = await Record.ExceptionAsync(() => _controller.Edit(projectId));

            Assert.IsType<HttpNotFoundException>(exception);
            Assert.NotNull(exception);
        }

        [Fact]
        public async Task Update_ValidModel_ShouldReturnRedirectToRouteResult()
        {
            projectViewModel.ProjectName = "Changed Project Name";
            _projectsRepoMock.Setup(r => r.GetProjectByIdAsync(projectViewModel.ID)).ReturnsAsync(project);
            _projectsRepoMock.Setup(r => r.SaveAllAsync()).ReturnsAsync(true);

            var result = await _controller.Update(projectViewModel.ID, projectViewModel);

            Assert.IsType<RedirectToRouteResult>(result);
        }

        [Fact]
        public async Task Update_InvalidModel_ShouldReturnViewResult()
        {
            projectViewModel.ProjectName = null;
            _controller.ModelState.AddModelError("ProjectName", "The Project Name field is required.");

            var result = await _controller.Update(projectViewModel.ID, projectViewModel);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            var model = Assert.IsType<ProjectFormViewModel>(viewResult.Model);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task Update_InvalidProjectId_ShouldThrowHttpNotFoundException()
        {
            _projectsRepoMock.Setup(r => r.GetProjectByIdAsync(projectViewModel.ID)).ReturnsAsync(null as Project);

            var exception = await Record.ExceptionAsync(() => _controller.Update(projectViewModel.ID, projectViewModel));

            Assert.IsType<HttpNotFoundException>(exception);
            Assert.NotNull(exception);
        }

    }
}
