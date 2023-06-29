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
        private UserManager<User> _userManager;
        private WebContext _webContext;

        public HomeController(UserManager<User> userManager, WebContext webContext)
        {
            _userManager = userManager;
            _webContext = webContext;
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity?.Name).Result;
            var viewModel = new IndexViewModel();

            viewModel.UserName = user.UserName;
            viewModel.Exp = user.Exp;
            viewModel.Coins = user.Coins;
            viewModel.CurrentLevelName = user.CurrentLevel.Name;

            viewModel.LevelDetails = _webContext
                .LevelRules
                .Where(x => x.MinExp <= user.Exp)
                .Select(x => new LevelDetailViewModel
                {
                    Name = x.Name,
                    Level = x.Level,
                    ExpSalaryRate = x.ExpSalaryRate,
                    LearningStepSize = x.LearningStepSize,
                    ImageUrl = x.LevelImageUrl
                })
                .ToList();

            return View(viewModel);
        }
    }
}