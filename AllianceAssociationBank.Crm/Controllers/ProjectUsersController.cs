using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Persistence;
using AllianceAssociationBank.Crm.Persistence.Repositories;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    // TODO: add logging
    //[RoutePrefix("Projects/{projectId}/Users")]
    [Authorize]
    public class ProjectUsersController : Controller
    {
        private IProjectRepository _repository;

        public ProjectUsersController()
        {
            _repository = new ProjectRepository(new CrmApplicationDbContext());
        }

        public ActionResult Index(int projectId)
        {
            var users = _repository.GetUsers(projectId);

            return PartialView("_UsersListPartial", Mapper.Map<List<UserFormViewModel>>(users));
        }

        public ActionResult Create(int projectId)
        {
            var model = new UserFormViewModel();
            model.ProjectID = projectId;

            return PartialView("_UserFormPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int projectId, UserFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView("_UserFormPartial", model);
                }

                var user = Mapper.Map<ProjectUser>(model);
                user.ProjectID = projectId;
                _repository.AddUser(user);
                await _repository.SaveAllAsync();

                return Index(projectId);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
        
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var user = await _repository.GetUserByIdAsync(id);

                if (user == null)
                {
                    return HttpNotFound();
                }

                var model = Mapper.Map<UserFormViewModel>(user);

                return PartialView("_UserFormPartial", model);
            }
            catch (Exception ex)
            {
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
                    return PartialView("_UserFormPartial", model);
                }

                var user = await _repository.GetUserByIdAsync(model.ID);
                if (user == null)
                {
                    return HttpNotFound();
                }

                Mapper.Map(model, user);
                await _repository.SaveAllAsync();

                return Index(user.ProjectID ?? 0);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var user = await _repository.GetUserByIdAsync(id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                var projectId = user.ProjectID ?? 0;

                _repository.RemoveUser(user);
                await _repository.SaveAllAsync();

                return Index(projectId);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError); ;
            }  
        }
    } 
}