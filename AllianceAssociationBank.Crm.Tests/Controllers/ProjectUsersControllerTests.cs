﻿using AllianceAssociationBank.Crm.Mappings;
using AllianceAssociationBank.Crm.Constants.Projects;
using AllianceAssociationBank.Crm.Controllers;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Xunit;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Constants.ProjectUsers;
using AllianceAssociationBank.Crm.Persistence.Enums;

namespace AllianceAssociationBank.Crm.Tests.Controllers
{
    public class ProjectUsersControllerTests
    {
        private ProjectUsersController controller;
        private IMapper mapper;

        private Mock<IProjectUserRepository> projectUsersRepoMock;

        private UserFormViewModel userViewModel;
        private ProjectUser user;

        public ProjectUsersControllerTests()
        {
            projectUsersRepoMock = new Mock<IProjectUserRepository>();
            mapper = CrmAutoMapperProfile.GetMapper();

            controller = new ProjectUsersController(projectUsersRepoMock.Object, mapper);
            // Mock http context so http response object is not null
            var response = new Mock<HttpResponseBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.SetupGet(c => c.Response).Returns(response.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);

            userViewModel = new UserFormViewModel()
            {
                ID = 10001,
                ProjectID = 1001,
                Name = "New User Name",
                Email = "email@email.com"
            };
            user = new ProjectUser()
            {
                ID = 10001,
                ProjectID = 1001,
                Name = "New User Name",
                Email = "email@email.com"
            };
        }

        [Fact]
        public void Index_ValidProjectId_PartialViewResult()
        {
            var users = new List<ProjectUser>()
            {
                new ProjectUser()
                {
                    Name = "User 1",
                    Email = "email1@email.com",
                    Active = true
                },
                new ProjectUser()
                {
                    Name = "User 2",
                    Email = "email2@email.com",
                    Active = true
                }
            };
            var projectId = 99;
            projectUsersRepoMock.Setup(r => r.GetUsers(projectId, UserFilter.All)).Returns(users.AsQueryable());

            var result = controller.Index(projectId);

            AssertHelper.AssertActionResult<PartialViewResult, UsersPagedListViewModel>(result, ProjectUsersView.UsersListPartial/*,users.Count*/);
        }

        [Fact]
        public void Index_InvalidProjectId_PartialViewResultWithZeroRecords()
        {
            var users = new List<ProjectUser>(); // Empty list
            var projectId = 1;
            projectUsersRepoMock.Setup(r => r.GetUsers(projectId, UserFilter.All)).Returns(users.AsQueryable());

            var result = controller.Index(projectId);

            AssertHelper.AssertActionResult<PartialViewResult, UsersPagedListViewModel> (result, ProjectUsersView.UsersListPartial/*, 0*/);
        }

        [Fact]
        public void Create_ValidState_PartialViewResult()
        {
            var projectId = 99;

            var result = controller.Create(projectId);

            AssertHelper.AssertActionResult<PartialViewResult, UserFormViewModel>(result, ProjectUsersView.UserFormPartial);
        }

        [Fact]
        public async Task Create_ValidModel_PartialViewResult()
        {
            var projectId = 99;
            userViewModel.ID = 0; // On create Id should be 0
            userViewModel.ProjectID = projectId;
            projectUsersRepoMock.Setup(r => r.SaveAllAsync()).ReturnsAsync(true);

            var result = await controller.Create(projectId, userViewModel);

            AssertHelper.AssertActionResult<PartialViewResult, UsersPagedListViewModel> (result, ProjectUsersView.UsersListPartial);
        }

        [Fact]
        public async Task Create_InvalidModel_ShouldReturnJsonErrorResult()
        {
            var projectId = 99;
            // On create Id should be 0
            userViewModel.ID = 0;
            userViewModel.ProjectID = projectId;
            userViewModel.Name = null;
            controller.ModelState.AddModelError("Name", "The Name field is required.");

            var result = await controller.Create(projectId, userViewModel);

            Assert.IsType<JsonErrorResult>(result);
        }


        [Fact]
        public async Task Edit_ValidUserId_PartialViewResult()
        {
            var userId = user.ID;
            projectUsersRepoMock.Setup(r => r.GetUserByIdAsync(userId)).ReturnsAsync(user);

            var result = await controller.Edit(99, userId);

            AssertHelper.AssertActionResult<PartialViewResult, UserFormViewModel>(result, ProjectUsersView.UserFormPartial);
        }

        [Fact]
        public async Task Edit_InvalidUserId_ShouldThrowHttpNotFoundException()
        {
            var userId = 1;
            projectUsersRepoMock.Setup(r => r.GetUserByIdAsync(userId)).ReturnsAsync(null as ProjectUser);

            var exception = await Record.ExceptionAsync(() => controller.Edit(99, userId));

            Assert.IsType<HttpNotFoundException>(exception);
            Assert.NotNull(exception);
        }


        [Fact]
        public async Task Update_ValidModel_PartialViewResult()
        {
            var projectId = userViewModel.ProjectID;
            var userId = userViewModel.ID;
            userViewModel.Name = "Updated name";
            projectUsersRepoMock.Setup(r => r.GetUserByIdAsync(userId)).ReturnsAsync(user);
            projectUsersRepoMock.Setup(r => r.SaveAllAsync()).ReturnsAsync(true);

            var result = await controller.Update(projectId, userId, userViewModel);

            AssertHelper.AssertActionResult<PartialViewResult, UsersPagedListViewModel> (result, ProjectUsersView.UsersListPartial);
        }

        [Fact]
        public async Task Update_InvalidModel_ShouldReturnJsonErrorResult()
        {
            var projectId = userViewModel.ProjectID;
            var userId = userViewModel.ID;
            userViewModel.Name = null;
            controller.ModelState.AddModelError("Name", "The Name field is required.");

            var result = await controller.Update(projectId, userId, userViewModel);

            Assert.IsType<JsonErrorResult>(result);
        }

        [Fact]
        public async Task Update_InvalidUserId_ShouldThrowHttpNotFoundException()
        {
            var userId = 1;
            var projectId = 1;
            projectUsersRepoMock.Setup(r => r.GetUserByIdAsync(userId)).ReturnsAsync(null as ProjectUser);

            var exception = await Record.ExceptionAsync(() => controller.Update(projectId, userId, userViewModel));

            Assert.IsType<HttpNotFoundException>(exception);
            Assert.NotNull(exception);
        }
    }
}
