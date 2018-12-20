using AllianceAssociationBank.Crm.Constants.Projects;
using AllianceAssociationBank.Crm.Core.Dtos;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Mappings;
using AllianceAssociationBank.Crm.Persistence;
using AllianceAssociationBank.Crm.Persistence.Queries;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Persistence.Queries
{
    public class ReportQueriesTests
    {
        private IReportQueries _reportQueries;
        private Mock<CrmApplicationDbContext> _mockDbContext;
        private Mock<DbSet<Project>> _mockProjectsDbSet;
        private Mock<DbSet<Employee>> _mockEmployeesDbSet;
        private List<Project> _projects; 

        public ReportQueriesTests()
        {
            _mockDbContext = new Mock<CrmApplicationDbContext>();
            _mockProjectsDbSet = new Mock<DbSet<Project>>();
            _mockEmployeesDbSet = new Mock<DbSet<Employee>>();
            _mockDbContext.Setup(c => c.Projects).Returns(() => _mockProjectsDbSet.Object);
            _mockDbContext.Setup(c => c.Employees).Returns(() => _mockEmployeesDbSet.Object);

            _reportQueries = new ReportQueries(_mockDbContext.Object, CrmAutoMapperProfile.GetMapper());

            _projects = new List<Project>()
            {
                new Project() { ID = 1, ProjectName = "Project 1", Users = new List<ProjectUser>() },
                new Project() { ID = 2, ProjectName = "Project 2", Users = new List<ProjectUser>() }
            };
            _mockProjectsDbSet.SetupData(_projects);
        }

        [Fact]
        public async Task GetBoardingDataSetAsync_ValidDataset_ShouldReturnTwoProjects()
        {
            _projects.Add(new Project() { ID = 3, ProjectName = "Name 3", Status = ProjectStatus.InProgress });
            _projects.Add(new Project() { ID = 4, ProjectName = "Name 4", Status = ProjectStatus.AuditConcern });

            var results = await _reportQueries.GetBoardingDataSetAsync();

            Assert.NotNull(results);
            Assert.Equal(2, results.Count());
        }

        [Fact]
        public async Task GetProjectsByOpsDataSetAsync_OneYearTimePeriod_ShouldReturnOneProject()
        {
            _projects.Add(new Project() { ID = 3, ProjectName = "Name 3", StartDate = new DateTime(2018, 6, 1) });
            _projects.Add(new Project() { ID = 4, ProjectName = "Name 4", StartDate = new DateTime(2017, 12, 1) });
            var startDate = new DateTime(2018, 1, 1);
            var endDate = new DateTime(2018, 12, 31);

            var results = await _reportQueries.GetProjectsByOpsDataSetAsync(startDate, endDate);

            Assert.Single(results);
        }

        [Fact]
        public async Task GetSoftwareTransitionDataSetAsync_ValidDataset_ShouldReturnOneProject()
        {
            _projects.Add(new Project() { ID = 3, ProjectName = "Name 3", Status = ProjectStatus.SoftwareTransition });

            var results = await _reportQueries.GetSoftwareTransitionDataSetAsync();

            Assert.NotNull(results);
            Assert.Single(results);
        }

        [Fact]
        public async Task GetCompletedAndHoldDataSetAsync_ValidDataset_ShouldReturnTwoProjects()
        {
            _projects.Add(new Project() { ID = 3, ProjectName = "Name 3", Status = ProjectStatus.Completed });
            _projects.Add(new Project() { ID = 4, ProjectName = "Name 4", Status = ProjectStatus.Deferred });

            var results = await _reportQueries.GetCompletedAndHoldDataSetAsync();

            Assert.NotNull(results);
            Assert.Equal(2, results.Count());
        }

        [Fact]
        public async Task GetCmcByIdDataSetAsync_ValidDataset_ShouldReturnTwoProjects()
        {
            var results = await _reportQueries.GetCmcByIdDataSetAsync();

            Assert.NotNull(results);
            Assert.Equal(2, results.Count());
        }

        [Fact]
        public async Task GetCmcByNameDataSetAsync_ValidDataset_ShouldReturnTwoProjects()
        {
            var results = await _reportQueries.GetCmcByNameDataSetAsync();

            Assert.NotNull(results);
            Assert.Equal(2, results.Count());
        }

        [Fact]
        public async Task GetAllInfoDataSetAsync_ValidDataset_ShouldReturnTwoProjects()
        {
            var results = await _reportQueries.GetAllInfoDataSetAsync();

            Assert.NotNull(results);
            Assert.Equal(2, results.Count());
        }

        [Fact]
        public async Task GetCDEmailsDataSetAsync_ValidDataset_ShouldReturnThreeProjects()
        {
            var project = new Project()
            {
                ID = 3,
                ProjectName = "Name 3",
                Users = new List<ProjectUser>()
                {
                    new ProjectUser() { ID = 11, Name = "User1", Email = "some@email.com", StatementEmail = true }
                }
            };
            _projects.Add(project);

            var results = await _reportQueries.GetCDEmailsDataSetAsync();

            Assert.NotNull(results);
            Assert.Equal(3, results.Count());
        }

        [Fact]
        public async Task GetCouponDataSetAsync_ValidDataset_ShouldReturnTwoProjects()
        {
            var results = await _reportQueries.GetCouponDataSetAsync();

            Assert.NotNull(results);
            Assert.Equal(2, results.Count());
        }

        [Fact]
        public async Task GetAchReportDataSetAsync_ValidProjectId_ShouldReturnOneProject()
        {
            var projectId = _projects.First().ID;

            var results = await _reportQueries.GetAchReportDataSetAsync(projectId);

            Assert.NotNull(results);
            Assert.Single(results);
        }

        [Fact]
        public async Task GetWelcomeChecklistDataSetAsync_SingleProject_ShouldReturnSingleProjectReportDataSetDto()
        {
            var projectId = _projects.First().ID;

            var results = await _reportQueries.GetWelcomeChecklistDataSetAsync(projectId);

            Assert.Single(results);
            Assert.IsAssignableFrom<IEnumerable<ProjectReportDataSetDto>>(results);
        }

        [Fact]
        public async Task GetEmployeesDataSetAsync_ValidDataset_ShouldReturnTwoEmployees()
        {
            var employees = new List<Employee>()
            {
                new Employee() { ID = 1, FirstName = "First 1", LastName = "Last 1" },
                new Employee() { ID = 1, FirstName = "First 2", LastName = "Last 2" }
            };
            _mockEmployeesDbSet.SetupData(employees);

            var results = await _reportQueries.GetEmployeesDataSetAsync();

            Assert.NotNull(results);
            Assert.Equal(2, results.Count());
        }
    }
}
