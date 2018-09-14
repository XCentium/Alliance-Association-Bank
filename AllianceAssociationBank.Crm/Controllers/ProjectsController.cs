using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Projects;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Helpers;
using AllianceAssociationBank.Crm.Persistence;
using AllianceAssociationBank.Crm.Persistence.Repositories;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
        private ISoftwareRepository _softwares;
        private IMapper _mapper;

        public ProjectsController (IProjectRepository projects, IEmployeeRepository employees, ISoftwareRepository softwares, IMapper mapper)
        {
            _projects = projects;
            _employees = employees;
            _softwares = softwares;
            _mapper = mapper;
        }

        [Authorize(Roles = UserRoleName.ReadWriteUser)]
        public async Task<ActionResult> Create()
        {
            ViewBag.Title = "Create Project";

            var model = new ProjectFormViewModel();
            await PopulateDropDownLists(model);

            return View(ProjectsView.ProjectForm, model);
        }

        [Authorize(Roles = UserRoleName.ReadWriteUser)]
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

        [Authorize(Roles = UserRoleName.ReadWriteUser)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(ProjectFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await PopulateDropDownLists(model);
                    return View(ProjectsView.ProjectForm, model);
                }

                var project = await _projects.GetProjectByIdAsync(model.ID);
                if (project == null)
                {
                    // TODO: need better error handeling
                    return View("Error");
                }

                _mapper.Map(model, project);
                await _projects.SaveAllAsync();

                TempData[SAVED] = true;
                return RedirectToAction(nameof(this.Edit), new { id = model.ID });

                // TODO: if nothing actually changes, SaveAllAsync will return false
                //if (await _repository.SaveAllAsync())
                //{
                //    return RedirectToAction(nameof(this.Edit), new { id = model.ID });
                //}
                //else
                //{
                //    return View("Error"); // TODO: need better error handeling
                //}
            }
            catch (Exception ex)
            {
                return View("Error");
                //throw;
            }
        }

        private async Task PopulateDropDownLists(ProjectFormViewModel model)
        {
            model.EmployeeList = (await _employees.GetEmployeesAsync()).Select(e => new SelectListItem()
                                                                        {
                                                                            Value = e.ID.ToString(),
                                                                            Text = e.FirstName + " " + e.LastName
                                                                        });
            model.SoftwareList = (await _softwares.GetSoftwaresAsync()).Select(s => new SelectListItem()
                                                                        {
                                                                            Value = s.ID.ToString(),
                                                                            Text = s.SoftwareName
                                                                        });
            model.InstitutionList = DropDownListHelper.InstitutionValues;
            model.LockboxSystemList = DropDownListHelper.LockboxSystemValues;
            model.LockboxStatusList = DropDownListHelper.LockboxStatusValues;
            model.StatusList = DropDownListHelper.StatusValues;
        }
    }
}