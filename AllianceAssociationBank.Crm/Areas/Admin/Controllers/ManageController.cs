using AllianceAssociationBank.Crm.Constants;
using System.Web.Mvc;

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