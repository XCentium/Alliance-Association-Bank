using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Projects;
using AllianceAssociationBank.Crm.Constants.ProjectUsers;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
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
        private const string EMAIL_SEPARATOR = "; ";

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

        [Authorize(Roles = UserRoleName.ReadWriteUser)]
        [Route("Create", Name = ProjectUsersControllerRoute.CreateUser)]
        public ActionResult Create(int projectId)
        {
            // TODO: if projectId is null need to show an error, but better way to do this
            if (projectId == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = new UserFormViewModel();
            model.ProjectID = projectId;
            // Default to active on create
            model.Active = true;

            return PartialView(ProjectUsersView.UserFormPartial, model);
        }

        [Authorize(Roles = UserRoleName.ReadWriteUser)]
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

        [Authorize(Roles = UserRoleName.ReadWriteUser)]
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

        [Route("EmailList", Name = ProjectUsersControllerRoute.GetEmailList)]
        public async Task<ActionResult> GetEmailList(int projectId, string emailList)
        {
            try
            {
                var emails = (await _userRepository.GetUsersByEmailList(projectId, emailList.ToLower()))
                    .Select(u => u.Email);

                ViewBag.ListName = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(emailList);
                ViewBag.EmailList = string.Join(EMAIL_SEPARATOR, emails);

                return PartialView(ProjectUsersView.UsersEmailListPartial);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    } 
}