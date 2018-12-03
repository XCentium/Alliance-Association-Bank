using AllianceAssociationBank.Crm.Areas.Admin.Constants.Employees;
using AllianceAssociationBank.Crm.Areas.Admin.Controllers;
using AllianceAssociationBank.Crm.Areas.Admin.ViewModels;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Mappings;
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
        public async Task Create_ValidEmployeeModel_ShouldReturnEmployeesListPartialView()
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
    }
}
