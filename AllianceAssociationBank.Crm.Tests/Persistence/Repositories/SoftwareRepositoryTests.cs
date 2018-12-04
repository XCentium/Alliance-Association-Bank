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
    public class SoftwareRepositoryTests
    {
        private ISoftwareRepository _repository;
        private Mock<CrmApplicationDbContext> _mockDbContext;
        private Mock<DbSet<Software>> _mockSoftwareDbSet;

        private List<Software> _softwareList;

        public SoftwareRepositoryTests()
        {
            _mockDbContext = new Mock<CrmApplicationDbContext>();
            _mockSoftwareDbSet = new Mock<DbSet<Software>>();
            _mockDbContext.Setup(c => c.Softwares).Returns(() => _mockSoftwareDbSet.Object);

            _softwareList = new List<Software>()
            {
                new Software() { ID = 1, SoftwareName = "Software 1" },
                new Software() { ID = 2, SoftwareName = "Software 2"}
            };
            _mockSoftwareDbSet.SetupData(_softwareList);

            _repository = new SoftwareRepository(_mockDbContext.Object);
        }

        [Fact]
        public async Task GetSoftwareAsync_TwoEntities_ShouldReturnSoftwareIEnumerable()
        {
            var results = await _repository.GetSoftwareAsync();

            Assert.Equal(2, results.Count());
        }

        [Fact]
        public async Task GetSoftwareByIdAsync_ValidId_ShouldReturnSoftwareEntity()
        {
            var softwareId = _softwareList.First().ID;

            var result = await _repository.GetSoftwareByIdAsync(softwareId);

            Assert.Equal(softwareId, result.ID);
        }

        [Fact]
        public async Task GetSoftwareByIdAsync_InvalidId_ShouldReturnNull()
        {
            var invalidSoftwareId = 199;

            var result = await _repository.GetSoftwareByIdAsync(invalidSoftwareId);

            Assert.Null(result);
        }

        [Fact]
        public void AddSoftware_NewEntity_ShouldAddEntityToDbSet()
        {
            var newSoftware = new Software()
            {
                ID = 3,
                SoftwareName = "New Software"
            };

            _repository.AddSoftware(newSoftware);

            Assert.Contains(newSoftware, _mockDbContext.Object.Softwares);
        }

        [Fact]
        public void RemoveSoftware_ValidEntity_ShouldRemoveEntityFromDbSet()
        {
            var softwareToRemove = _softwareList.First();

            _repository.RemoveSoftware(softwareToRemove);

            Assert.DoesNotContain(softwareToRemove, _mockDbContext.Object.Softwares);
        }

        [Fact]
        public async Task SaveAllAsync_AddOneEntity_ShouldReturnTrue()
        {
            var newSoftware = new Software()
            {
                ID = 3,
                SoftwareName = "New Software"
            };
            _mockDbContext.Setup(c => c.SaveChangesAsync()).ReturnsAsync(1);

            _repository.AddSoftware(newSoftware);
            var result = await _repository.SaveAllAsync();

            Assert.True(result);
        }
    }
}
