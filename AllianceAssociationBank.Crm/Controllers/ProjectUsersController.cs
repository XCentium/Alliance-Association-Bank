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
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    // TODO: add logging
    [Authorize]
    [RoutePrefix("Projects/{projectId}/Users")]
    public class ProjectUsersController : Controller
    {
        private IProjectUserRepository _userRepository;

        public ProjectUsersController(IProjectUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("Index", Name = "GetProjectUsers")]
        public ActionResult Index(int projectId, string filter = "all")
        {
            filter = filter.ToLower();

            var users = _userRepository.GetUsers(projectId)
                .Where(u =>
                    filter == "all" ||
                    (filter == "admin" && u.Admin) ||
                    (filter == "active" && u.Active) ||
                    (filter == "inactive" && !u.Active));

            return PartialView("_UsersListPartial", Mapper.Map<List<UserFormViewModel>>(users));
        }

        [Route("Create", Name = "CreateProjectUser-Get")]
        public ActionResult Create(int projectId)
        {
            var model = new UserFormViewModel();
            model.ProjectID = projectId;
            // Default to active on create
            model.Active = true;

            return PartialView("_UserFormPartial", model);
        }

        // TODO: if projectId is null need to show an error
        [Route("Create", Name = "CreateProjectUser-Post")]
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

                user.SetDefaultsOnCreate();

                _userRepository.AddUser(user);
                await _userRepository.SaveAllAsync();

                return Index(projectId);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [Route("Edit/{id}", Name = "EditProjectUser-Get")]
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);

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

        [Route("Update/{id}", Name = "UpdateProjectUser-Post")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int projectId, int id, UserFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView("_UserFormPartial", model);
                }

                var user = await _userRepository.GetUserByIdAsync(id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                Mapper.Map(model, user);

                user.CheckForStatusChange();

                await _userRepository.SaveAllAsync();

                return Index(projectId);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // No delete capability
        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    try
        //    {
        //        var user = await _repository.GetUserByIdAsync(id);
        //        if (user == null)
        //        {
        //            return HttpNotFound();
        //        }

        //        var projectId = user.ProjectID ?? 0;

        //        _repository.RemoveUser(user);
        //        await _repository.SaveAllAsync();

        //        return Index(projectId);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError); ;
        //    }  
        //}
    } 
}