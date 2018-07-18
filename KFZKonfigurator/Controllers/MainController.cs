using System.Web.Mvc;

namespace KFZKonfigurator.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index() {
            return RedirectToAction("Index", "Configuration");
        }

        public ActionResult SwitchLanguage(string code) {
            Global.Language = code;
            return Index();
        }
    }
}