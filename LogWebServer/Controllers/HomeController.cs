using System.Web.Hosting;
using System.Web.Mvc;

namespace LogWebServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}