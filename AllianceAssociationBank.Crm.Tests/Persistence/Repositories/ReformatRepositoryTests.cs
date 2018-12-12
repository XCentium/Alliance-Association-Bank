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
    public class ReformatRepositoryTests
    {
        private IReformatRepository _repository;
        private Mock<CrmApplicationDbContext> _mockDbContext;
        private Mock<DbSet<Aq2Reformat>> _mockAq2ReformatDbSet;

        private List<Aq2Reformat> _reformats;

        public ReformatRepositoryTests()
        {
            _mockDbContext = new Mock<CrmApplicationDbContext>();
            _mockAq2ReformatDbSet = new Mock<DbSet<Aq2Reformat>>();
            _mockDbContext.Setup(c => c.Aq2Reformats).Returns(() => _mockAq2ReformatDbSet.Object);

            _reformats = new List<Aq2Reformat>()
            {
                new Aq2Reformat() { ID = 1, ReformatName = "Reformat 1" },
                new Aq2Reformat() { ID = 2, ReformatName = "Reformat 2"}
            };
            _mockAq2ReformatDbSet.SetupData(_reformats);

            _repository = new ReformatRepository(_mockDbContext.Object);
        }

        [Fact]
        public async Task GetAq2ReformatsAsync_TwoEntities_ShouldReturnAq2ReformatIEnumerable()
        {
            var results = await _repository.GetAq2ReformatsAsync();

            Assert.Equal(2, results.Count());
        }

        [Fact]
        public async Task GetAq2ReformatByIdAsync_ValidId_ShouldReturnAq2ReformatEntity()
        {
            var reformatId = _reformats.First().ID;

            var result = await _repository.GetAq2ReformatByIdAsync(reformatId);

            Assert.Equal(reformatId, result.ID);
        }

        [Fact]
        public async Task GetAq2ReformatByIdAsync_InvalidId_ShouldReturnNull()
        {
            var invalidReformatId = 199;

            var result = await _repository.GetAq2ReformatByIdAsync(invalidReformatId);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetAq2ReformatByNameAsync_ValidName_ShouldReturnAq2ReformatEntity()
        {
            var reformatName = _reformats.First().ReformatName;

            var result = await _repository.GetAq2ReformatByNameAsync(reformatName);

            Assert.Equal(reformatName, result.ReformatName);
        }

        [Fact]
        public void AddAq2Reformat_NewEntity_ShouldAddEntityToDbSet()
        {
            var newReformat = new Aq2Reformat()
            {
                ID = 3,
                ReformatName = "Reformat 3"
            };

            _repository.AddAq2Reformat(newReformat);

            Assert.Contains(newReformat, _mockDbContext.Object.Aq2Reformats);
        }

        [Fact]
        public void RemoveAq2Reformat_ValidEntity_ShouldRemoveEntityFromDbSet()
        {
            var reformatToRemove = _reformats.First();

            _repository.RemoveAq2Reformat(reformatToRemove);

            Assert.DoesNotContain(reformatToRemove, _mockDbContext.Object.Aq2Reformats);
        }

        [Fact]
        public async Task SaveAllAsync_AddOneEntity_ShouldReturnTrue()
        {
            var newReformat = new Aq2Reformat()
            {
                ID = 3,
                ReformatName = "Reformat 3"
            };
            _mockDbContext.Setup(c => c.SaveChangesAsync()).ReturnsAsync(1);

            _repository.AddAq2Reformat(newReformat);
            var result = await _repository.SaveAllAsync();

            Assert.True(result);
        }
    }
}
