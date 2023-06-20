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
        private SignInManager<User> _signInManager;
        private WebContext _webContext;

        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager, WebContext webContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _webContext = webContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AuthUserViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = new User
            {
                Email = viewModel.Email,
                UserName = viewModel.Email,
                CurrentLevel = _webContext.LevelRules.Single(x => x.Level == 1)
            };

            var identityResult = await _userManager.CreateAsync(user, viewModel.Password);
            if (!identityResult.Succeeded)
            {
                identityResult
                    .Errors
                    .ToList()
                    .ForEach(error => ModelState.AddModelError(nameof(AuthUserViewModel.Email), error.Description));
                return View(viewModel);
            }

            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthUserViewModel viewModel)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError(nameof(AuthUserViewModel.Email), "Incorrect Email or Password");
                return View(viewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Index()
        {
            var user = _userManager.FindByNameAsync(User.Identity?.Name).Result;
            var viewModel = new IndexViewModel();
            viewModel.UserName = user.UserName;
            viewModel.CurrentLevelName = user.CurrentLevel.Name;
            viewModel.Exp = user.Exp;
            viewModel.Coins = user.Coins;

            return View(viewModel);
        }
    }
}