using ClickerWeb.DAL;
using ClickerWeb.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClickerWeb.Controllers
{
    public class DoController : Controller
    {
        private UserManager<User> _userManager;
        private WebContext _webContext;

        public DoController(UserManager<User> userManager, WebContext webContext)
        {
            _userManager = userManager;
            _webContext = webContext;
        }

        public IActionResult Learn()
        {
            var user = _userManager.FindByNameAsync(User.Identity?.Name).Result;
            user.Exp += user.CurrentLevel.LearningStepSize;
            _webContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Work()
        {
            var user = _userManager.FindByNameAsync(User.Identity?.Name).Result;
            user.Coins += user.Exp * user.CurrentLevel.ExpSalaryRate;
            _webContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
