using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Persistence;
using AllianceAssociationBank.Crm.Persistence.Repositories;
using AllianceAssociationBank.Crm.ViewModels;
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
    public class ProjectController : Controller
    {
        private IProjectRepository _repository;

        public ProjectController ()
        {
            _repository = new ProjectRepository(new CrmApplicationDbContext());
        }

        [HttpGet]
        public async Task<ActionResult> Index(int? ProjectId)
        {
            var model = new ProjectsViewModel()
            {
                Projects = await _repository.GetAllProjectsAsync()
            };
            model.SelectedProjectId = ProjectId;
            var project = model.Projects.FirstOrDefault(p => p.ID == model.SelectedProjectId);

            model.SelectedProject = new ProjectDetailViewModel();

            if (project != null)
            {
                model.SelectedProject.Id = project.ID;
                model.SelectedProject.Name = project.ProjectName;
                model.SelectedProject.Phone = project.Phone;
                model.SelectedProject.PhysicalAddress = project.Address;
                model.SelectedProject.PhysicalCity = project.City;
                model.SelectedProject.PhysicalState = project.State;
                model.SelectedProject.PhysicalZipCode = project.ZipCode;
                model.SelectedProject.Notes = project.Notes;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeSelection(ProjectsViewModel model)
        {
            return RedirectToAction("Index", new { ProjectId = model.SelectedProjectId });
        }
    }
}