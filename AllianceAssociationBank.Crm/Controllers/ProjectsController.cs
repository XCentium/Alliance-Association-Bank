using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
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
    //[Authorize]
    public class ProjectsController : Controller
    {
        private IProjectRepository _repository;

        public ProjectsController ()
        {
            _repository = new ProjectRepository(new CrmApplicationDbContext());
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                var project = await _repository.GetProjectById(id ?? 0);
                var model = Mapper.Map<ProjectDetailViewModel>(project) ?? new ProjectDetailViewModel();

                //model.SelectedProjectId = id;
                model.Projects = await _repository.GetProjectsList();

                return View(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult ChangeSelection(int? id)
        {
            return RedirectToAction("Edit", new { id });
        }

        [HttpPost]
        public async Task<ActionResult> Update(ProjectDetailViewModel model)
        {
            try
            {
                var project = await _repository.GetProjectById(model.ID);

                if (project == null)
                {
                    // TODO: need better error handeling
                    return HttpNotFound();
                }

                Mapper.Map(model, project);

                await _repository.SaveAllAsync();

                return RedirectToAction("Edit", new { id = model.ID });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}