using AllianceAssociationBank.Crm.Areas.Admin.Constants;
using AllianceAssociationBank.Crm.Areas.Admin.Constants.Employees;
using AllianceAssociationBank.Crm.Areas.Admin.Controllers;
using AllianceAssociationBank.Crm.Areas.Admin.ViewModels;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Mappings;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace AllianceAssociationBank.Crm.Tests.Areas.Admin.Controllers
{
    public class EmployeesControllerTests
    {
        private EmployeesController _controller;

        private IMapper _mapper;   
        private Mock<IEmployeeRepository> _mockEmployeeRepository;
        private List<Employee> _employees;

        public EmployeesControllerTests()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _mapper = CrmAutoMapperProfile.GetMapper();

            _controller = new EmployeesController(_mockEmployeeRepository.Object, _mapper);

            _employees = new List<Employee>()
            {
                new Employee() { ID = 1, FirstName = "First Name 1", LastName = "Last Name 1" },
                new Employee() { ID = 2, FirstName = "First Name 2", LastName = "Last Name 2" },
            };

        }

        [Fact]
        public async Task Index_TwoEmployees_ShouldReturnEmployeesListPartialView()
        {
            _mockEmployeeRepository.Setup(r => r.GetEmployeesAsync()).ReturnsAsync(_employees);

            var result = await _controller.Index();

            AssertHelper.AssertActionResult<PartialViewResult, List<EmployeeViewModel>>(
                result, 
                EmployeesView.EmployeesListPartial, 
                2);
        }

        [Fact]
        public void Create_NewEmployeeEntry_ShouldReturnEmployeeFormPartialView()
        {
            var result = _controller.Create();

            AssertHelper.AssertActionResult<PartialViewResult, EmployeeViewModel>(
                result,
                EmployeesView.EmployeeFormPartial);
        }


        [Fact]
        public async Task Create_ValidNewEmployee_ShouldReturnEmployeesListPartialView()
        {
            var employee = new EmployeeViewModel()
            {
                FirstName = "New First",
                LastName = "New Last"
            };
            _mockEmployeeRepository.Setup(r => r.SaveAllAsync()).ReturnsAsync(true);

            var result = await _controller.Create(employee);

            AssertHelper.AssertActionResult<PartialViewResult, List<EmployeeViewModel>>(
                result,
                EmployeesView.EmployeesListPartial);
        }

        [Fact]
        public async Task Create_DuplicateEmployee_ShouldReturnJsonErrorResult()
        {
            var existingEmployee = _employees.First();
            var duplicateName = new EmployeeViewModel()
            {
                FirstName = existingEmployee.FirstName,
                LastName = existingEmployee.LastName
            };
            _mockEmployeeRepository
                .Setup(r => r.GetEmployeeByNameAsync(existingEmployee.FirstName, existingEmployee.LastName))
                .ReturnsAsync(existingEmployee);

            var result = await _controller.Create(duplicateName);

            var jsonError = Assert.IsType<JsonErrorResult>(result);
        }

        [Fact]
        public async Task Delete_ValidEmployeeId_ShouldReturnEmployeesListPartialView()
        {
            var employee = _employees.First();
            var employeeId = employee.ID;

            _mockEmployeeRepository
                .Setup(r => r.GetEmployeeByIdAsync(employeeId))
                .ReturnsAsync(employee);
            _mockEmployeeRepository
                .Setup(r => r.SaveAllAsync())
                .ReturnsAsync(true);
            _mockEmployeeRepository
                .Setup(r => r.GetEmployeesAsync())
                .ReturnsAsync(_employees);

            var result = await _controller.Delete(employee.ID);

            AssertHelper.AssertActionResult<PartialViewResult, List<EmployeeViewModel>>(
                result,
                EmployeesView.EmployeesListPartial);
        }

        [Fact]
        public void ConfirmDelete_ValidEmployeeId_ShouldReturnPartialViewWithConfirmDeleteViewModel()
        {
            var employeeId = _employees.First().ID;

            var result = _controller.ConfirmDelete(employeeId);

            var viewModel = AssertHelper.AssertActionResult<PartialViewResult, ConfirmDeleteViewModel>(result);
            Assert.Equal(employeeId, viewModel.RecordIdToDelete);
            Assert.Equal(EmployeesControllerRoute.DeleteEmployee, viewModel.AjaxDeleteRouteName);
            Assert.Equal(HtmlElementIdentifier.ManageValuesContent, viewModel.AjaxUpdateTargetId);
        }
    }
}
