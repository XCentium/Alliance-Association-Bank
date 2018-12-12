using AllianceAssociationBank.Crm.Constants;
using AllianceAssociationBank.Crm.Constants.Projects;
using AllianceAssociationBank.Crm.Constants.ProjectUsers;
using AllianceAssociationBank.Crm.Core.Interfaces;
using AllianceAssociationBank.Crm.Core.Models;
using AllianceAssociationBank.Crm.Exceptions;
using AllianceAssociationBank.Crm.Filters;
using AllianceAssociationBank.Crm.Helpers;
using AllianceAssociationBank.Crm.Persistence.Enums;
using AllianceAssociationBank.Crm.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    [RoutePrefix("Projects/{projectId}/Users")]
    [RedirectOnInvalidAjaxRequest(ControllerName.Projects, ProjectsControllerAction.Edit, "projectId")]
    public class ProjectUsersController : Controller
    {
        private IProjectUserRepository _userRepository;
        private IMapper _mapper;

        private const int PAGE_SIZE = 5;

        public ProjectUsersController(IProjectUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [Route("Index", Name = ProjectUsersControllerRoute.GetUsers)]
        public ActionResult Index(int projectId, int page = 1, string filter = UserFilterString.All)
        {
            filter = filter.ToLower();

            var users = _userRepository.GetUsers(projectId, filter.ToUserFilterEnum());

            var usersViewModel = users.ProjectTo<UserFormViewModel>(_mapper.ConfigurationProvider);
            var pagedModel = new UsersPagedListViewModel(projectId, usersViewModel, page, PAGE_SIZE);

            return PartialView(ProjectUsersView.UsersListPartial, pagedModel);
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [Route("Create", Name = ProjectUsersControllerRoute.CreateUser)]
        public ActionResult Create(int projectId)
        {
            if (projectId == 0)
            {
                return new JsonErrorResult(HttpStatusCode.BadRequest, DefaultErrorText.Message.CreateProjectFirst);
            }

            var model = new UserFormViewModel();
            // Set view model defaults on create
            model.SetDefaults(projectId);

            return PartialView(ProjectUsersView.UserFormPartial, model);
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [Route("Create", Name = ProjectUsersControllerRoute.CreateUserHttpPost)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int projectId, UserFormViewModel model)
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

        [Route("Edit/{id}", Name = ProjectUsersControllerRoute.EditUser)]
        public async Task<ActionResult> Edit(int projectId, int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                throw new HttpNotFoundException(DefaultErrorText.Message.FormatForRecordNotFound("user", id));
            }

            var model = _mapper.Map<UserFormViewModel>(user);

            return PartialView(ProjectUsersView.UserFormPartial, model);
        }

        [Authorize(Roles = UserRole.EditAccessRoles)]
        [Route("Update/{id}", Name = ProjectUsersControllerRoute.UpdateUser)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(int projectId, int id, UserFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return PartialView(ProjectUsersView.UserFormPartial, model);
            }

            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new HttpNotFoundException(DefaultErrorText.Message.FormatForRecordNotFound("user", id));
            }

            _mapper.Map(model, user);

            user.CheckForStatusChange();

            await _userRepository.SaveAllAsync();

            return Index(projectId);
        }

        [Route("EmailList", Name = ProjectUsersControllerRoute.GetEmailList)]
        public async Task<ActionResult> GetEmailList(int projectId, string emailList)
        {
            var emails = (await _userRepository.GetUsersByEmailList(projectId, emailList.ToLower()))
                .Select(u => u.Email);

            ViewBag.ListName = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(emailList);
            ViewBag.EmailList = EmailListHelper.Concatenate(emails);

            return PartialView(ProjectUsersView.UsersEmailListDialogPartial);
        }
    } 
}