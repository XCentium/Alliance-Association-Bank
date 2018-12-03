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
    public class EmployeeRepositoryTests
    {
        private IEmployeeRepository _employeeRepository;
        private Mock<CrmApplicationDbContext> _mockDbContext;
        private Mock<DbSet<Employee>> _mockEmployeeDbSet;

        private List<Employee> _employees;

        public EmployeeRepositoryTests()
        {
            _mockDbContext = new Mock<CrmApplicationDbContext>();
            _mockEmployeeDbSet = new Mock<DbSet<Employee>>();
            _mockDbContext.SetupGet(c => c.Employees).Returns(() => _mockEmployeeDbSet.Object);

            _employees = new List<Employee>()
            {
                new Employee() { ID = 1, FirstName = "First 1", LastName = "Last 1" },
                new Employee() { ID = 2, FirstName = "First 2", LastName = "Last 2" }
            };
            _mockEmployeeDbSet.SetupData(_employees);

            _employeeRepository = new EmployeeRepository(_mockDbContext.Object);
        }

        [Fact]
        public async Task GetEmployeesAsync_TwoEntities_ShouldReturnEmployeeIEnumerable()
        {
            var results = await _employeeRepository.GetEmployeesAsync();

            Assert.Equal(2, results.Count());
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_ValidId_ShouldReturnEmployeeEntity()
        {
            var employeeId = _employees.First().ID;

            var result = await _employeeRepository.GetEmployeeByIdAsync(employeeId);

            Assert.Equal(employeeId, result.ID);

        }

        [Fact]
        public async Task GetEmployeeByNameAsync_ValidName_ShouldReturnEmployeeEntity()
        {
            var employee = _employees.First();

            var result = await _employeeRepository.GetEmployeeByNameAsync(employee.FirstName, employee.LastName);

            Assert.Equal(employee, result);
        }

        [Fact]
        public void AddEmployee_ValidEntity_ShouldAddEntityToDbSet()
        {
            var newEmployee = new Employee()
            {
                ID = 3,
                FirstName = "First 3",
                LastName = "Last 3"
            };

            _employeeRepository.AddEmployee(newEmployee);

            Assert.Contains(newEmployee, _mockDbContext.Object.Employees);
        }

        [Fact]
        public void RemoveEmployee_ValidEntity_ShouldRemoveEntityFromDbSet()
        {
            var employeeToRemove = _employees.First();

            _employeeRepository.RemoveEmployee(employeeToRemove);

            Assert.DoesNotContain(employeeToRemove, _mockDbContext.Object.Employees);
        }

        [Fact]
        public async Task SaveAllAsync_OneEntity_ShouldReturnTrue()
        {
            var employee = new Employee()
            {
                ID = 3,
                FirstName = "First 3",
                LastName = "Last 3"
            };
            _mockDbContext.Setup(c => c.SaveChangesAsync()).ReturnsAsync(1);

            _employeeRepository.AddEmployee(employee);
            var result = await _employeeRepository.SaveAllAsync();

            Assert.True(result);
        }
    }
}
