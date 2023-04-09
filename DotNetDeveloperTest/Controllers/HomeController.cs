using System.Web.Mvc;

namespace DotNetDeveloperTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return Redirect("Help");
        }
    }
}