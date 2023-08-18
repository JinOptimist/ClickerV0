using Microsoft.AspNetCore.Mvc;

namespace ClickerWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}