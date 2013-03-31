using System.Web.Mvc;

namespace SamStock.Web.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {

            return View();
        }

    }
}