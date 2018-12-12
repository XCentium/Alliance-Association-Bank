using AllianceAssociationBank.Crm.Areas.Admin.Constants;
using AllianceAssociationBank.Crm.Areas.Admin.Constants.Employees;
using AllianceAssociationBank.Crm.Areas.Admin.Constants.Manage;
using AllianceAssociationBank.Crm.Areas.Admin.ViewModels;
using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Filters;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Areas.Admin.Controllers
{
    [Authorize(Roles = UserRole.Admin)]
    [RouteArea(AreaName.Admin)]
    [RoutePrefix("Manage/Employees")]
    [RedirectOnInvalidAjaxRequest(Constants.ControllerName.Manage, ManageControllerAction.Index)]
    public class EmployeesController : Controller
    {
        private IEmployeeRepository _employeeRepository;
        private IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [Route("Index", Name = EmployeesControllerRoute.GetEmployees)]
        public async Task<ActionResult> Index()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            var viewModels = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);

            return PartialView(EmployeesView.EmployeesListPartial, viewModels);
        }

        [Route("Create", Name = EmployeesControllerRoute.CreateEmployee)]
        public ActionResult Create()
        {
            return PartialView(EmployeesView.EmployeeFormPartial, new EmployeeViewModel());
        }

        [Route("Create", Name = EmployeesControllerRoute.CreateEmployeeHttpPost)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeeViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // TODO: test this!
                return new JsonErrorResult(HttpStatusCode.BadRequest);
            }

            viewModel.TrimValues();

            var existing = await _employeeRepository.GetEmployeeByNameAsync(viewModel.FirstName, viewModel.LastName);
            if (existing != null)
            {
                return new JsonErrorResult(HttpStatusCode.BadRequest, "The employee record already exists.");
            }

            var employee = _mapper.Map<Employee>(viewModel);
            _employeeRepository.AddEmployee(employee);
            await _employeeRepository.SaveAllAsync();

            return await Index();
        }

        [Route("Delete/{id}", Name = EmployeesControllerRoute.ConfirmDeleteEmployee)]
        public ActionResult ConfirmDelete(int id)
        {
            var viewModel = new ConfirmDeleteViewModel()
            {
                RecordIdToDelete = id,
                AjaxDeleteRouteName = EmployeesControllerRoute.DeleteEmployee,
                AjaxUpdateTargetId = HtmlElementIdentifier.ManageValuesContent,
                ConfirmText = "Are you sure you want to delete this record?"
            };

            return PartialView(SharedView.ConfirmDeleteDialogPartial, viewModel);
        }

        // TODO: should we add ValidateAntiForgeryToken?
        [Route("Delete/{id}", Name = EmployeesControllerRoute.DeleteEmployee)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                throw new HttpNotFoundException(DefaultErrorText.Message.FormatForRecordNotFound("employee", id));
            }

            _employeeRepository.RemoveEmployee(employee);
            await _employeeRepository.SaveAllAsync();

            return await Index();
        }
    }
}