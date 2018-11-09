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
    public class CheckScannerRepositoryTests
    {
        private ICheckScannerRepository _checkScannerRepository;
        private Mock<CrmApplicationDbContext> _mockDbContext;
        private Mock<DbSet<CheckScanner>> _mockCheckScannersDbSet;

        private List<CheckScanner> _scanners;
        private int _projectId = 1;

        public CheckScannerRepositoryTests()
        {
            _mockDbContext = new Mock<CrmApplicationDbContext>();
            _mockCheckScannersDbSet = new Mock<DbSet<CheckScanner>>();
            _mockDbContext.SetupGet(c => c.CheckScanners).Returns(() => _mockCheckScannersDbSet.Object);

            _checkScannerRepository = new CheckScannerRepository(_mockDbContext.Object);

            _scanners = new List<CheckScanner>()
            {
                new CheckScanner() { ID = 20, ProjectID = 1, Model = "Model 1" },
                new CheckScanner() { ID = 21, ProjectID = 1,  Model = "Model 2" },
                new CheckScanner() { ID = 22, ProjectID = 2,  Model = "Model 3" }
            };
        }

        [Fact]
        public void GetScanners_ValidProjectId_ShouldReturnScannersList()
        {
            _mockCheckScannersDbSet.SetupData(_scanners);

            var results = _checkScannerRepository.GetScanners(_projectId);

            Assert.Equal(_scanners.Where(u => u.ProjectID == _projectId).Count(), results.Count());
        }

        [Fact]
        public void GetScanners_InvalidProjectId_ShouldReturnEmptyList()
        {
            _mockCheckScannersDbSet.SetupData(_scanners);

            var results = _checkScannerRepository.GetScanners(99);

            Assert.Empty(results);
        }

        [Fact]
        public async Task GetScannerByIdAsync_ValidId_ShouldReturnScanner()
        {
            _mockCheckScannersDbSet.SetupData(_scanners);
            var scannerId = _scanners.First().ID;

            var result = await _checkScannerRepository.GetScannerByIdAsync(scannerId);

            Assert.NotNull(result);
            Assert.Equal(scannerId, result.ID);
        }

        [Fact]
        public async Task GetScannerByIdAsync_InvalidId_ShouldReturnNull()
        {
            _mockCheckScannersDbSet.SetupData(_scanners);
            var scannerId = 99;

            var result = await _checkScannerRepository.GetScannerByIdAsync(scannerId);

            Assert.Null(result);
        }

        [Fact]
        public void AddScanner_NewScanner_ShouldAddEntityToDbSet()
        {
            _mockCheckScannersDbSet.SetupData(_scanners);
            var scanner = new CheckScanner()
            {
                ID = 23,
                ProjectID = _projectId,
                Model = "Model 4"
            };

            _checkScannerRepository.AddScanner(scanner);

            Assert.NotNull(_mockDbContext.Object.CheckScanners.Where(s => s.ID == scanner.ID).SingleOrDefault());
        }

        [Fact]
        public async Task SaveAllAsync_SaveOneEntity_ShouldReturnTrue()
        {
            _mockCheckScannersDbSet.SetupData(_scanners);
            var scanner = new CheckScanner()
            {
                ID = 23,
                ProjectID = _projectId,
                Model = "Model 4"
            };
            _mockDbContext.Setup(c => c.SaveChangesAsync()).ReturnsAsync(1);

            _checkScannerRepository.AddScanner(scanner);
            var result = await _checkScannerRepository.SaveAllAsync();

            Assert.True(result);
        }
    }
}
