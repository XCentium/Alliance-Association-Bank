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
        private IProjectRepository _repository;
        private IEmployeeRepository _employees;
        private ISoftwareRepository _softwares;

        public ProjectsController ()
        {
            var context = new CrmApplicationDbContext();
            _repository = new ProjectRepository(context);
            _employees = new EmployeeRepository(context);
            _softwares = new SoftwareRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id = 0)
        {
            try
            {
                var project = await _repository.GetProjectById(id);
                var model = Mapper.Map<ProjectFormViewModel>(project) ?? new ProjectFormViewModel();

                await PopulateDropDownLists(model);
                //model.Projects = await _repository.GetProjectsListAsync();
                //model.Employees = await _employees.GetEmployeesAsync();

                return View(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult ChangeSelection(int id = 0)
        {
            return RedirectToAction(nameof(this.Edit), new { id });
        }

        public async Task<ActionResult> Create(ProjectFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await PopulateDropDownLists(model);
                    return View("Edit", model);
                }

                var project = Mapper.Map<Project>(model);
                _repository.AddProject(project);

                if (await _repository.SaveAllAsync())
                {
                    return RedirectToAction(nameof(this.Edit), new { id = project.ID });
                }
                else
                {
                    return View("Error"); // TODO: need better error handeling
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProjectFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await PopulateDropDownLists(model);
                    return View("Edit", model);
                }

                var project = await _repository.GetProjectById(model.ID);

                if (project == null)
                {
                    //return HttpNotFound();
                    return View("Error"); // TODO: need better error handeling
                }

                Mapper.Map(model, project);

                if (await _repository.SaveAllAsync())
                {
                    return RedirectToAction(nameof(this.Edit), new { id = model.ID });
                }
                else
                {
                    return View("Error"); // TODO: need better error handeling
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task PopulateDropDownLists(ProjectFormViewModel model)
        {
            model.ProjectList = await _repository.GetProjectListAsync();
            model.EmployeeList = await _employees.GetEmployeeListAsync();
            model.SoftwareList = await _softwares.GetSoftwareListAsync();
            model.LockboxSystemList = DropDownListHelper.LockboxSystemValues;
            model.LockboxStatusList = DropDownListHelper.LockboxStatusValues;
        }
    }
}