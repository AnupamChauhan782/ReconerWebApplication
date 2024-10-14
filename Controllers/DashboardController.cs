using Microsoft.AspNetCore.Mvc;

namespace ReCornerApplication.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
