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
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Controllers
{
    public class ApiProjectsControllerTests
    {
        ProjectsController controller;

        Mock<IProjectRepository> projectsRepoMock;

        public ApiProjectsControllerTests()
        {
            projectsRepoMock = new Mock<IProjectRepository>();

            controller = new ProjectsController(projectsRepoMock.Object);
        }

        [Fact]
        public async Task Get_ValidSearchTerm_ProjectsDtoList()
        {
            var projects = new List<Project>()
            {
                new Project()
                {
                    ID = 1001,
                    ProjectName = "Project name 1"
                },
                new Project()
                {
                    ID = 1002,
                    ProjectName = "Project name 2"
                },
            };
            var searchTerm = "name";
            projectsRepoMock
                .Setup(r => r.GetProjectsBySearchPhraseAsync(searchTerm, SortOrder.Ascending))
                .ReturnsAsync(projects);

            var results = await controller.Get(searchTerm);

            var listOfProjects = Assert.IsAssignableFrom<IEnumerable<ProjectDto>>(results);
            Assert.NotNull(listOfProjects);
            Assert.Equal(projects.Count, listOfProjects.ToList().Count);
        }
    }
}
