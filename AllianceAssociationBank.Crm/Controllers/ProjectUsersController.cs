using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Persistence;
using AllianceAssociationBank.Crm.Persistence.Repositories;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    // TODO: add logging
    //[RoutePrefix("Projects/{projectId}/Users")]
    public class ProjectUsersController : Controller
    {
        private IProjectRepository _repository;

        public ProjectUsersController()
        {
            _repository = new ProjectRepository(new CrmApplicationDbContext());
        }

        public ActionResult Create()
        {
            var model = new UserFormViewModel();

            return PartialView("_ProjectUserFormPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserFormViewModel model)
        {
            try
            {
                var projectId = 1437; // TODO: need to set this

                if (!ModelState.IsValid)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView("_ProjectUserFormPartial", model);
                }

                var user = Mapper.Map<ProjectUser>(model);
                user.ProjectID = projectId;
                _repository.AddProjectUser(user);

                if (await _repository.SaveAllAsync())
                {
                    var project = await _repository.GetProjectByIdAsync(projectId);
                    var projectViewModel = Mapper.Map<ProjectFormViewModel>(project);

                    return PartialView("_UsersTabPartial", projectViewModel);
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
        
        //[Route("{id}")]
        public async Task<ActionResult> Edit(/*int projectId,*/ int id)
        {
            try
            {
                var user = await _repository.GetProjectUserByIdAsync(id);

                if (user == null)
                {
                    return HttpNotFound();
                }

                var model = Mapper.Map<UserFormViewModel>(user);

                return PartialView("_ProjectUserFormPartial", model);
            }
            catch (Exception ex)
            {
                //return View("Error");
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(UserFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView("_ProjectUserFormPartial", model);
                }

                var user = await _repository.GetProjectUserByIdAsync(model.ID);
                if (user == null)
                {
                    return HttpNotFound();
                }

                Mapper.Map(model, user);
                await _repository.SaveAllAsync();

                var projectId = user.ProjectID ?? 0;
                var project = await _repository.GetProjectByIdAsync(projectId);
                var projectViewModel = Mapper.Map<ProjectFormViewModel>(project);

                return PartialView("_UsersTabPartial", projectViewModel);
            }
            catch (Exception ex)
            {
                //return View("Error");
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    } 
}