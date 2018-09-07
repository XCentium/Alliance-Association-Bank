using AllianceAssociationBank.Crm.Constants.Projects;
using AllianceAssociationBank.Crm.Constants.ProjectUsers;
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
        private IMapper _mapper;

        private const string FILTER_ALL = "all";
        private const string FILTER_ADMIN = "admin";
        private const string FILTER_ACTIVE = "active";
        private const string FILTER_INACTIVE = "inactive";

        public ProjectUsersController(IProjectUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [Route("Index", Name = ProjectUsersControllerRoute.GetUsers)]
        public ActionResult Index(int projectId, string filter = FILTER_ALL)
        {
            filter = filter.ToLower();

            var users = _userRepository.GetUsers(projectId)
                .Where(u =>
                    filter == FILTER_ALL ||
                    (filter == FILTER_ADMIN && u.Admin) ||
                    (filter == FILTER_ACTIVE && u.Active) ||
                    (filter == FILTER_INACTIVE && !u.Active));

            return PartialView(ProjectUsersView.UsersListPartial, _mapper.Map<List<UserFormViewModel>>(users));
        }

        [Route("Create", Name = ProjectUsersControllerRoute.CreateUser)]
        public ActionResult Create(int projectId)
        {
            var model = new UserFormViewModel();
            model.ProjectID = projectId;
            // Default to active on create
            model.Active = true;

            return PartialView(ProjectUsersView.UserFormPartial, model);
        }

        // TODO: if projectId is null need to show an error
        [Route("Create", Name = ProjectUsersControllerRoute.CreateUserHttpPost)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int projectId, UserFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView(ProjectUsersView.UserFormPartial, model);
                }

                var user = _mapper.Map<ProjectUser>(model);

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

        [Route("Edit/{id}", Name = ProjectUsersControllerRoute.EditUser)]
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);

                if (user == null)
                {
                    return HttpNotFound();
                }

                var model = _mapper.Map<UserFormViewModel>(user);

                return PartialView(ProjectUsersView.UserFormPartial, model);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [Route("Update/{id}", Name = ProjectUsersControllerRoute.UpdateUser)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int projectId, int id, UserFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return PartialView(ProjectUsersView.UserFormPartial, model);
                }

                var user = await _userRepository.GetUserByIdAsync(id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                _mapper.Map(model, user);

                user.CheckForStatusChange();

                await _userRepository.SaveAllAsync();

                return Index(projectId);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    } 
}