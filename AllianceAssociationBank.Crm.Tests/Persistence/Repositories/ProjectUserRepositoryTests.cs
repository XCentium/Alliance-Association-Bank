using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.ProjectUsers;
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
    public class ProjectUserRepositoryTests
    {
        private IProjectUserRepository _projectUserRepository;
        private Mock<CrmApplicationDbContext> _mockDbContext;
        private Mock<DbSet<ProjectUser>> _mockProjectUsersDbSet;

        private List<ProjectUser> _users;
        private int _projectId = 1;

        public ProjectUserRepositoryTests()
        {
            _mockDbContext = new Mock<CrmApplicationDbContext>();
            _mockProjectUsersDbSet = new Mock<DbSet<ProjectUser>>();
            _mockDbContext.SetupGet(c => c.ProjectUsers).Returns(() => _mockProjectUsersDbSet.Object);

            _projectUserRepository = new ProjectUserRepository(_mockDbContext.Object);

            _users = new List<ProjectUser>()
            {
                new ProjectUser() { ID = 10, ProjectID = 1, Name = "User 1", Active = true },
                new ProjectUser() { ID = 11, ProjectID = 1,  Name = "User 2", Active = true },
                new ProjectUser() { ID = 12, ProjectID = 2,  Name = "User 3", Active = true }
            };
        }

        [Fact]
        public void GetUsers_ValidProjectId_ShouldReturnUsersList()
        {
            _mockProjectUsersDbSet.SetupData(_users);

            var results = _projectUserRepository.GetUsers(_projectId);

            Assert.Equal(_users.Where(u => u.ProjectID == _projectId).Count(), results.Count());
        }

        [Fact]
        public void GetUsers_InvalidProjectId_ShouldReturnEmptyList()
        {
            _mockProjectUsersDbSet.SetupData(_users);

            var results = _projectUserRepository.GetUsers(99);

            Assert.Empty(results);
        }

        [Fact]
        public void GetUsers_AdminUsersOnly_ShouldReturnUsersList()
        {
            var adminUser = new ProjectUser()
            {
                ID = 13,
                ProjectID = _projectId,
                Active = true,
                Admin = true
            };
            _users.Clear();
            _users.Add(adminUser);
            _mockProjectUsersDbSet.SetupData(_users);

            var results = _projectUserRepository.GetUsers(_projectId, UserFilterValue.Admin);

            Assert.Equal(_users.Where(u => u.ProjectID == _projectId && u.Admin).Count(), results.Count());
        }

        [Fact]
        public void GetUsers_ActiveUsersOnly_ShouldReturnUsersList()
        {
            var anotherUser = new ProjectUser()
            {
                ID = 13,
                ProjectID = _projectId,
                Active = false,
            };
            _users.Clear();
            _users.Add(anotherUser);
            _mockProjectUsersDbSet.SetupData(_users);

            var results = _projectUserRepository.GetUsers(_projectId, UserFilterValue.Active);

            Assert.Equal(_users.Where(u => u.ProjectID == _projectId && u.Active).Count(), results.Count());
        }

        [Fact]
        public void GetUsers_InactiveUsersOnly_ShouldReturnUsersList()
        {
            var anotherUser = new ProjectUser()
            {
                ID = 13,
                ProjectID = _projectId,
                Active = false,
            };
            _users.Clear();
            _users.Add(anotherUser);
            _mockProjectUsersDbSet.SetupData(_users);

            var results = _projectUserRepository.GetUsers(_projectId, UserFilterValue.Inactive);

            Assert.Equal(_users.Where(u => u.ProjectID == _projectId && !u.Active).Count(), results.Count());
        }

        [Fact]
        public async Task GetUsersByEmailList_StatementEmails_ShouldReturnUsersList()
        {
            var anotherUser = new ProjectUser()
            {
                ID = 13,
                ProjectID = _projectId,
                StatementEmail = true,
            };
            _users.Clear();
            _users.Add(anotherUser);
            _mockProjectUsersDbSet.SetupData(_users);

            var results = await _projectUserRepository.GetUsersByEmailList(_projectId, UsersEmailListName.StatementEmails);

            Assert.Equal(_users.Where(u => u.ProjectID == _projectId && u.StatementEmail).Count(), results.Count());
        }


        [Fact]
        public async Task GetUsersByEmailList_LockboxEmails_ShouldReturnUsersList()
        {
            var anotherUser = new ProjectUser()
            {
                ID = 13,
                ProjectID = _projectId,
                LockboxEmail = true,
            };
            _users.Clear();
            _users.Add(anotherUser);
            _mockProjectUsersDbSet.SetupData(_users);

            var results = await _projectUserRepository.GetUsersByEmailList(_projectId, UsersEmailListName.LockboxEmails);

            Assert.Equal(_users.Where(u => u.ProjectID == _projectId && u.LockboxEmail).Count(), results.Count());
        }

        [Fact]
        public async Task GetUsersByEmailList_AchEmails_ShouldReturnUsersList()
        {
            var anotherUser = new ProjectUser()
            {
                ID = 13,
                ProjectID = _projectId,
                ACHEmail = true,
            };
            _users.Clear();
            _users.Add(anotherUser);
            _mockProjectUsersDbSet.SetupData(_users);

            var results = await _projectUserRepository.GetUsersByEmailList(_projectId, UsersEmailListName.AchEmails);

            Assert.Equal(_users.Where(u => u.ProjectID == _projectId && u.ACHEmail).Count(), results.Count());
        }

        [Fact]
        public async Task GetUserByIdAsync_ValidId_ShouldReturnUser()
        {
            _mockProjectUsersDbSet.SetupData(_users);
            var userId = _users.First().ID;

            var result = await _projectUserRepository.GetUserByIdAsync(userId);

            Assert.NotNull(result);
            Assert.Equal(userId, result.ID);
        }

        [Fact]
        public async Task GetUserByIdAsync_InvalidId_ShouldReturnNull()
        {
            _mockProjectUsersDbSet.SetupData(_users);
            var userId = 99;

            var result = await _projectUserRepository.GetUserByIdAsync(userId);

            Assert.Null(result);
        }

        [Fact]
        public void AddUser_NewUser_ShouldAddEntityToDbSet()
        {
            _mockProjectUsersDbSet.SetupData(_users);
            var user = new ProjectUser()
            {
                ID = 14,
                ProjectID = _projectId,
                Name = "User Name"
            };

            _projectUserRepository.AddUser(user);

            Assert.NotNull(_mockDbContext.Object.ProjectUsers.Where(u => u.ID == user.ID).SingleOrDefault());
        }

        [Fact]
        public async Task SaveAllAsync_SaveOneEntity_ShouldReturnTrue()
        {
            _mockProjectUsersDbSet.SetupData(_users);
            var user = new ProjectUser()
            {
                ID = 14,
                ProjectID = _projectId,
                Name = "User Name"
            };
            _mockDbContext.Setup(c => c.SaveChangesAsync()).ReturnsAsync(1);

            _projectUserRepository.AddUser(user);
            var result = await _projectUserRepository.SaveAllAsync();

            Assert.True(result);
        }
    }
}
