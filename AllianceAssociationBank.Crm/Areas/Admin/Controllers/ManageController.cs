using AllianceAssociationBank.Crm.Constants;
using System.Web.Mvc;
using System.Web.SessionState;

namespace AllianceAssociationBank.Crm.Areas.Admin.Controllers
{
    [Authorize(Roles = UserRole.Admin)]
    public class ManageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}