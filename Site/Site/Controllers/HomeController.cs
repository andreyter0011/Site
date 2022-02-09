using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
