using ClickerWeb.DAL;
using ClickerWeb.DAL.Models;
using ClickerWeb.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity?.Name).Result;
            var viewModel = new IndexViewModel();

            viewModel.UserName = user.UserName;
            viewModel.Exp = user.Exp;
            viewModel.Coins = user.Coins;

            return View(viewModel);
        }
    }
}