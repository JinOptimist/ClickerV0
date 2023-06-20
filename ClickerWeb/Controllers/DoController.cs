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

        public IActionResult Learn(int level)
        {
            var user = _userManager.FindByNameAsync(User.Identity?.Name).Result;
            var levelDetail = _webContext.LevelRules.Single(x => x.Level == level);
            user.Exp += levelDetail.LearningStepSize;
            _webContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Work(int level)
        {
            var user = _userManager.FindByNameAsync(User.Identity?.Name).Result;
            var levelDetail = _webContext.LevelRules.Single(x => x.Level == level);
            user.Coins += user.Exp * levelDetail.ExpSalaryRate;
            _webContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
