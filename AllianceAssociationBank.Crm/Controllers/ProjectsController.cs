using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Projects;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Helpers;
using AllianceAssociationBank.Crm.Providers;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.SessionState;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private const string SAVED = "SAVED";
        private const string ERROR = "ERROR";

        private IProjectRepository _projects;
        private IEmployeeRepository _employees;
        private ISoftwareRepository _software;
        private IReformatRepository _reformats;
        private IMapper _mapper;

        public ProjectsController (IProjectRepository projects, 
                                   IEmployeeRepository employees, 
                                   ISoftwareRepository software,
                                   IReformatRepository reformats,
                                   IMapper mapper)
        {
            _projects = projects;
            _employees = employees;
            _software = software;
            _reformats = reformats;
            _mapper = mapper;
        }

        // Use cookie to store TempData
        protected override ITempDataProvider CreateTempDataProvider()
        {
            return new CookieTempDataProvider();
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        public async Task<ActionResult> Create()
        {
            var model = new ProjectFormViewModel();
            await PopulateDropDownLists(model);

            // Set default values on create
            model.SetDefaults();

            ViewBag.Title = "Create Project";
            return View(ProjectsView.ProjectForm, model);
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProjectFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropDownLists(model);
                model.SaveIndicator = ERROR;
                return View(ProjectsView.ProjectForm, model);
            }

            var project = _mapper.Map<Project>(model);
            _projects.AddProject(project);
            await _projects.SaveAllAsync();

            TempData[SAVED] = true; 
            return RedirectToAction(nameof(this.Edit), new { id = project.ID });
        }

        public async Task<ActionResult> Edit(int id)
        {
            var project = await _projects.GetProjectByIdAsync(id);

            if (project == null)
            {
                throw new HttpNotFoundException(UserErrorContent.Message.FormatMessageForRecordNotFound("project", id));   
            }

            var model = _mapper.Map<ProjectFormViewModel>(project);
            await PopulateDropDownLists(model);

            if (TempData.ContainsKey(SAVED))
            {
                model.SaveIndicator = SAVED;
                TempData.Remove(SAVED);
            }

            ViewBag.Title = "Edit Project";
            return View(ProjectsView.ProjectForm, model);
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, ProjectFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropDownLists(model);
                model.SaveIndicator = ERROR;
                return View(ProjectsView.ProjectForm, model);
            }

            var project = await _projects.GetProjectByIdAsync(model.ID);
            if (project == null)
            {
                throw new HttpNotFoundException(UserErrorContent.Message.FormatMessageForRecordNotFound("project", id));
            }

            // Reset PMC/CMC ID value if a user with ReadWrite role attempts to change it.
            model.ResetCmcIdOnUnauthorized(User, project.LockboxCMCID);

            _mapper.Map(model, project);
            await _projects.SaveAllAsync();

            TempData[SAVED] = true;
            return RedirectToAction(nameof(this.Edit), new { id = model.ID });
        }

        private async Task PopulateDropDownLists(ProjectFormViewModel model)
        {
            model.EmployeeList = (await _employees.GetEmployeesAsync())
                .Select(e => new SelectListItem()
                {
                    Value = e.ID.ToString(),
                    Text = e.FirstName + " " + e.LastName
                })
                .ToList();

            model.InstitutionList = DropDownListHelper.InstitutionValues;
            model.LockboxStatusList = DropDownListHelper.LockboxStatusValues;
            model.StatusList = DropDownListHelper.StatusValues;
            model.XmlUsageList = DropDownListHelper.XmlUsageValues;

            model.Aq2ReformatList = (await _reformats.GetReformatsAsync())
                .Select(r => new SelectListItem()
                {
                    Value = r.ID.ToString(),
                    Text = r.ReformatName
                })
                .ToList();

            // Check if user custom value needs to be added to dropdownlist
            var lockboxSystemList = DropDownListHelper.LockboxSystemValues.ToList();
            model.LockboxSystemList = CheckAndAddCustomValueToList(lockboxSystemList, model.LockboxSystem);

            var softwareList = (await _software.GetSoftwareAsync())
                .Select(s => s.SoftwareName)
                .ToList();

            var migrationSoftwareList = new List<string>(softwareList);
            // Check if user custom value needs to be added to dropdownlist
            model.SoftwareList = CheckAndAddCustomValueToList(softwareList, model.Software);
            model.MigratingToSoftwareList = CheckAndAddCustomValueToList(migrationSoftwareList, model.MigratingToSoftware);
        }

        private IList<string> CheckAndAddCustomValueToList(IList<string> list, string customValue)
        {
            if (!list.Any(i => i == customValue))
            {
                list.Add(customValue);
            }

            return list;
        }
    }
}