using AllianceAssociationBank.Crm.ViewModels;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index", new HomeViewModel());
        }
    }
}