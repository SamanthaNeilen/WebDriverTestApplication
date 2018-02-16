using System.Web.Mvc;
using WebDriverTestApplication.Shared.Models;

namespace WebDriverTestApplication.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new CustomerModel());
        }

        public ActionResult Save()
        {
            return View();
        }
    }
}