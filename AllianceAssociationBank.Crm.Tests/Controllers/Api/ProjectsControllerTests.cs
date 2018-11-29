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

using System.Data.Entity.Infrastructure;
using AllianceAssociationBank.Crm.Tests.TestHelpers.Extensions;

namespace AllianceAssociationBank.Crm.Tests.Controllers.Api
{
    public class ProjectsControllerTests
    {
        ProjectsController _controller;

        Mock<IProjectRepository> _mockProjectRepository;
        private IMapper _mapper;

        public ProjectsControllerTests()
        {
            _mockProjectRepository = new Mock<IProjectRepository>();
            _mapper = CrmAutoMapperProfile.GetMapper();

            _controller = new ProjectsController(_mockProjectRepository.Object, _mapper);

        }

        [Fact]
        public void Get_ValidSearchTerm_ShouldReturnProjectDtoIEnumerable()
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
            _mockProjectRepository
                .Setup(r => r.GetProjectsBySearchTerm(searchTerm, SortOrder.Ascending, true))
                .Returns(projects.AsQueryable());

            var results = _controller.Get(searchTerm, true);

            var listOfProjects = Assert.IsAssignableFrom<IEnumerable<ProjectDto>>(results);
            Assert.Equal(2, listOfProjects.ToList().Count);
        }
    }
}
