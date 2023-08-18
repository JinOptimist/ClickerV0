using ClickerWeb.DAL;
using ClickerWeb.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClickerWeb.Controllers
{
    public class HomeController : Controller
    {
        private WebContext _webContext;
        private UserManager<User> _userManager;

        public HomeController(WebContext webContext, UserManager<User> userManager)
        {
            _webContext = webContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userCount = _webContext.Users.Count();
            return View(userCount);
        }
    }
}