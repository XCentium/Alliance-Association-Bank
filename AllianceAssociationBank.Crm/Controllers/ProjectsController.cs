using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Projects;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Helpers;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    //[ValidateInput(false)]
    public class ProjectsController : Controller
    {
        private const string SAVED = "SAVED";

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

        [Authorize(Roles = UserRole.EditAccessRoles)]
        public async Task<ActionResult> Create()
        {
            ViewBag.Title = "Create Project";

            var model = new ProjectFormViewModel();
            await PopulateDropDownLists(model);
            // Default Start Date to today on create
            model.StartDate = DateTime.Today;

            return View(ProjectsView.ProjectForm, model);
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProjectFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await PopulateDropDownLists(model);
                    return View(ProjectsView.ProjectForm, model);
                }

                var project = _mapper.Map<Project>(model);
                _projects.AddProject(project);
                await _projects.SaveAllAsync();

                TempData[SAVED] = true;
                return RedirectToAction(nameof(this.Edit), new { id = project.ID });
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                ViewBag.Title = "Edit Project";

                var project = await _projects.GetProjectByIdAsync(id);

                if (project == null)
                {
                    // TODO: need better error handeling
                    return View("Error");    
                }

                var model = _mapper.Map<ProjectFormViewModel>(project);
                await PopulateDropDownLists(model);

                if (TempData.ContainsKey(SAVED))
                {
                    model.SaveIndicator = SAVED;
                    TempData.Remove(SAVED);
                }

                return View(ProjectsView.ProjectForm, model);
            }
            catch (Exception ex)
            {
                return View("Error");
                //throw;
            }
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int id, ProjectFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropDownLists(model);
                return View(ProjectsView.ProjectForm, model);
            }

            //throw new InvalidOperationException();

            var project = await _projects.GetProjectByIdAsync(model.ID);
            if (project == null)
            {
                // TODO: need better error handeling
                return View("Error");
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

            model.Aq2ReformatList = (await _reformats.GetAq2ReformatsAsync())
                .Select(r => new SelectListItem()
                {
                    Value = r.ID.ToString(),
                    Text = r.ReformatName
                })
                .ToList();

            // Check if user custom value needs to be added to dropdownlist
            var lockboxSystemList = DropDownListHelper.LockboxSystemValues.ToList();
            model.LockboxSystemList = CheckAndAddCustomValueToList(lockboxSystemList, model.LockboxSystem);

            var softwareList = (await _software.GetSoftwaresAsync())
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