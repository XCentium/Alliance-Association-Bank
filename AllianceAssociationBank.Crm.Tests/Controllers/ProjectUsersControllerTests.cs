using AllianceAssociationBank.Crm.App_Start;
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
using System.Web.Mvc;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Controllers
{
    public class ProjectUsersControllerTests
    {
        private ProjectUsersController controller;
        private IMapper mapper;

        private Mock<IProjectUserRepository> projectUsersRepoMock;

        //private UserFormViewModel userViewModel;
        //private ProjectUser user;

        public ProjectUsersControllerTests()
        {
            projectUsersRepoMock = new Mock<IProjectUserRepository>();
            mapper = DefaultMappingProfile.GetMapper();

            controller = new ProjectUsersController(projectUsersRepoMock.Object, mapper);
        }

        [Fact]
        public void Index_ValidProjectId_ReturnsPartialViewResult()
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
            projectUsersRepoMock.Setup(r => r.GetUsers(projectId)).Returns(users);

            var result = controller.Index(projectId);

            var viewResult = Assert.IsType<PartialViewResult>(result);
            Assert.NotNull(viewResult);
            var model = Assert.IsType<List<UserFormViewModel>>(viewResult.Model);
            Assert.NotNull(model);
            Assert.True(model.Count == 2);
        }
    }
}
