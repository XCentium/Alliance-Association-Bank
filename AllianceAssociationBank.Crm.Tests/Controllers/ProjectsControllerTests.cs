using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
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
        private ProjectsController controller;
        private IMapper mapper;

        private Mock<IProjectRepository> projectsRepoMock;
        private Mock<IEmployeeRepository> employeesRepoMock;
        private Mock<ISoftwareRepository> softwareRepoMock;
        private Mock<IReformatRepository> reformatRepoMock;

        private ProjectFormViewModel projectViewModel;
        private Project project;

        public ProjectsControllerTests()
        {
            projectsRepoMock = new Mock<IProjectRepository>();
            employeesRepoMock = new Mock<IEmployeeRepository>();
            softwareRepoMock = new Mock<ISoftwareRepository>();
            reformatRepoMock = new Mock<IReformatRepository>();
            mapper = CrmAutoMapperProfile.GetMapper();

            controller = new ProjectsController(projectsRepoMock.Object, employeesRepoMock.Object, softwareRepoMock.Object, reformatRepoMock.Object, mapper);

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
        public async Task Create_ValidState_ResultIsNotNull()
        {
            var result = await controller.Create();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            var model = Assert.IsType<ProjectFormViewModel>(viewResult.Model);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task Create_ValidModel_RedirectToRouteResult()
        {
            projectViewModel.ID = 0; // On create Id should be 0
            projectsRepoMock.Setup(r => r.SaveAllAsync()).ReturnsAsync(true);

            var result = await controller.Create(projectViewModel);

            Assert.IsType<RedirectToRouteResult>(result);
        }

        [Fact]
        public async Task Create_InvalidModel_ViewResult()
        {
            var inputModel = new ProjectFormViewModel();
            controller.ModelState.AddModelError("ProjectName", "The Project Name field is required.");

            var result = await controller.Create(inputModel);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            var model = Assert.IsType<ProjectFormViewModel>(viewResult.Model);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task Edit_ValidProjectId_ViewResult()
        {
            projectsRepoMock.Setup(r => r.GetProjectByIdAsync(project.ID)).ReturnsAsync(project);

            var result = await controller.Edit(project.ID);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            var model = Assert.IsType<ProjectFormViewModel>(viewResult.Model);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task Edit_InvalidProjectId_ErrorViewResult()
        {
            var projectId = 99;
            projectsRepoMock.Setup(r => r.GetProjectByIdAsync(projectId)).ReturnsAsync(null as Project);

            var result = await controller.Edit(projectId);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            Assert.Equal("Error", viewResult.ViewName);
        }

        [Fact]
        public async Task Update_ValidModel_RedirectToRouteResult()
        {
            projectViewModel.ProjectName = "Changed Project Name";
            projectsRepoMock.Setup(r => r.GetProjectByIdAsync(projectViewModel.ID)).ReturnsAsync(project);
            projectsRepoMock.Setup(r => r.SaveAllAsync()).ReturnsAsync(true);

            var result = await controller.Update(projectViewModel.ID, projectViewModel);

            Assert.IsType<RedirectToRouteResult>(result);
        }

        [Fact]
        public async Task Update_InvalidModel_ViewResult()
        {
            projectViewModel.ProjectName = null;
            controller.ModelState.AddModelError("ProjectName", "The Project Name field is required.");

            var result = await controller.Update(projectViewModel.ID, projectViewModel);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            var model = Assert.IsType<ProjectFormViewModel>(viewResult.Model);
            Assert.NotNull(model);
        }

        [Fact]
        public async Task Update_InvalidProjectId_ErrorViewResult()
        {
            projectsRepoMock.Setup(r => r.GetProjectByIdAsync(projectViewModel.ID)).ReturnsAsync(null as Project);

            var result = await controller.Update(projectViewModel.ID, projectViewModel);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);
            Assert.Equal("Error", viewResult.ViewName);
        }

    }
}
