using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Persistence;
using AllianceAssociationBank.Crm.Persistence.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Persistence.Repositories
{
    public class ProjectRepositoryTests
    {
        private IProjectRepository _projectRepository;
        private Mock<CrmApplicationDbContext> _mockDbContext;
        private Mock<DbSet<Project>> _mockProjectsDbSet;

        private List<Project> _projects;

        public ProjectRepositoryTests()
        {
            _mockDbContext = new Mock<CrmApplicationDbContext>();
            _mockProjectsDbSet = new Mock<DbSet<Project>>();
            _mockDbContext.SetupGet(c => c.Projects).Returns(() => _mockProjectsDbSet.Object);

            _projectRepository = new ProjectRepository(_mockDbContext.Object);

            _projects = new List<Project>()
            {
                new Project() { ID = 1, ProjectName = "Test 1" },
                new Project() { ID = 2, ProjectName = "Test 2" },
            };
        }

        [Fact]
        public async Task GetProjectsAsync_AllEntities_ShouldReturnProjectList()
        {
            _mockProjectsDbSet.SetupData(_projects);
            //_mockDbContext.SetupGet(c => c.Projects).Returns(() => _mockProjectDbSet.Object);

            var results = await _projectRepository.GetProjectsAsync();

            Assert.Equal(_projects.Count, results.Count());
        }

        [Fact]
        public async Task GetProjectByIdAsync_ValidId_ShouldReturnProject()
        {
            _mockProjectsDbSet.SetupData(_projects);
            var projectId = _projects.First().ID;

            var result = await _projectRepository.GetProjectByIdAsync(projectId);

            Assert.NotNull(result);
            Assert.Equal(projectId, result.ID);
        }

        [Fact]
        public async Task GetProjectByIdAsync_InvalidId_ShouldReturnNull()
        {
            _mockProjectsDbSet.SetupData(_projects);
            var projectId = 99;

            var result = await _projectRepository.GetProjectByIdAsync(projectId);

            Assert.Null(result);
        }

        [Fact]
        public void AddProject_NewProject_ShouldAddEntityToDbSet()
        {
            _mockProjectsDbSet.SetupData(_projects);
            var project = new Project()
            {
                ID = 11,
                ProjectName = "New Project"
            };

            _projectRepository.AddProject(project);

            Assert.NotNull(_mockDbContext.Object.Projects.Where(p => p.ID == project.ID).SingleOrDefault());
        }

        [Fact]
        public async Task SaveAllAsync_SaveOneEntity_ShouldReturnTrue()
        {
            _mockProjectsDbSet.SetupData(_projects);
            var project = new Project()
            {
                ID = 11,
                ProjectName = "New Project"
            };
            _mockDbContext.Setup(c => c.SaveChangesAsync()).ReturnsAsync(1);

            _projectRepository.AddProject(project);
            var result = await _projectRepository.SaveAllAsync();

            Assert.True(result);
        }

        //[Fact]
        //public void GetProjectsBySearchTerm_SearchByProjectNameFuzzy_ShouldReturnCorrectProject()
        //{
        //    var project = new Project()
        //    {
        //        ID = 3,
        //        ProjectName = "First Property Bank LLC"
        //    };
        //    projects.Add(project);
        //    _mockProjectDbSet.SetupData(projects);
        //    var term = "first llc";

        //    var results = _projectRepository.GetProjectsBySearchTerm(term, SortOrder.Ascending);

        //    Assert.Equal(1, results.Count());
        //    Assert.Equal(project.ID, results.FirstOrDefault().ID);
        //}
    }
}
