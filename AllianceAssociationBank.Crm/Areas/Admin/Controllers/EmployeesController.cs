using AllianceAssociationBank.Crm.Areas.Admin.Constants.Employees;
using AllianceAssociationBank.Crm.Areas.Admin.ViewModels;
using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Areas.Admin.Controllers
{
    [Authorize(Roles = UserRole.Admin)]
    public class EmployeesController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            var viewModel = await _employeeRepository.GetEmployeesAsync();

            return PartialView(EmployeesView.EmployeesListPartial, viewModel);
        }

        public ActionResult Create()
        {
            return PartialView("FormViewName", new EmployeeViewModel());
        }

        public async Task<ActionResult> Create(EmployeeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // TODO: test this (need to disable JS validation)
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView("FormViewName", viewModel);
            }

            //var employee = _mapper.Map<Employee>(viewModel);
            //_employeeRepository.AddEmployee(employee);
            //await _employeeRepository.SaveAllAsync();

            return await Index();
        }

        public ActionResult ConfirmDelete(int id)
        {
            var viewModel = new ConfirmDeleteViewModel()
            {
                RecordIdToDelete = id,
                AjaxDeleteRouteName = "",
                AjaxUpdateTargetId = "value-list-content",
                ConfirmText = "Are you sure you want to delete this record?"
            };

            return PartialView(SharedView.ConfirmDeleteDialogPartial, viewModel);
        }

        public async Task<ActionResult> Delete(int id)
        {
            //var employee = _employeeRepository.GetEmployeeByIdAsync();
            //if (employee == null)
            //{
            //    throw new HttpNotFoundException(DefaultErrorText.Message.FormatForRecordNotFound("employee", id));
            //}

            //_employeeRepository.RemoveEmployee(employee);
            //await _employeeRepository.SaveAllAsync();

            return await Index();
        }
    }
}