using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Controllers.Api;
using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AllianceAssociationBank.Crm.Mappings;
using Xunit;
using AutoMapper;
using AllianceAssociationBank.Crm.Persistence.Enums;

namespace AllianceAssociationBank.Crm.Tests.Controllers
{
    public class ApiProjectsControllerTests
    {
        ProjectsController controller;

        Mock<IProjectRepository> projectsRepoMock;

        private IMapper mapper;

        public ApiProjectsControllerTests()
        {
            projectsRepoMock = new Mock<IProjectRepository>();
            mapper = CrmAutoMapperProfile.GetMapper();

            controller = new ProjectsController(projectsRepoMock.Object);

        }

        [Fact]
        public void Get_ValidSearchTerm_ShouldReturnTwoProjectDtos()
        {
            var projects = new List<Project>()
            {
                new Project()
                {
                    ID = 1001,
                    ProjectName = "Project name 1",
                    Active = true
                },
                new Project()
                {
                    ID = 1002,
                    ProjectName = "Project name 2",
                    Active = true
                },
            };
            var searchTerm = "name";
            projectsRepoMock
                .Setup(r => r.GetProjectsBySearchTerm(searchTerm, SortOrder.Ascending, true))
                .Returns(projects.AsQueryable());

            var results = controller.Get(searchTerm);

            var listOfProjects = Assert.IsAssignableFrom<IEnumerable<ProjectDto>>(results);
            Assert.Equal(2, listOfProjects.ToList().Count);
        }
    }
}
