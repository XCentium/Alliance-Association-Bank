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

        public async Task<ActionResult> Create()
        {
            var model = new ProjectFormViewModel();
            await PopulateDropDownLists(model);

            return View("ProjectForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProjectFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await PopulateDropDownLists(model);
                    return View("ProjectForm", model);
                }

                var project = Mapper.Map<Project>(model);
                _repository.AddProject(project);

                if (await _repository.SaveAllAsync())
                {
                    return RedirectToAction(nameof(this.Edit), new { id = project.ID });
                }
                else
                {
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
                throw;
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var project = await _repository.GetProjectByIdAsync(id);

                if (project == null)
                {
                    // TODO: need better error handeling
                    return View("Error");    
                }

                var model = Mapper.Map<ProjectFormViewModel>(project);

                await PopulateDropDownLists(model);

                return View("ProjectForm", model);
            }
            catch (Exception ex)
            {
                return View("Error");
                throw;
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(ProjectFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    await PopulateDropDownLists(model);
                    return View("ProjectForm", model);
                }

                var project = await _repository.GetProjectByIdAsync(model.ID);
                if (project == null)
                {
                    // TODO: need better error handeling
                    return View("Error");
                }

                Mapper.Map(model, project);
                await _repository.SaveAllAsync();

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
                throw;
            }
        }

        private async Task PopulateDropDownLists(ProjectFormViewModel model)
        {
            model.ProjectList = await _repository.GetProjectListAsync();
            model.EmployeeList = await _employees.GetEmployeeListAsync();
            model.SoftwareList = await _softwares.GetSoftwareListAsync();
            model.InstitutionList = DropDownListHelper.InstitutionValues;
            model.LockboxSystemList = DropDownListHelper.LockboxSystemValues;
            model.LockboxStatusList = DropDownListHelper.LockboxStatusValues;
        }
    }
}