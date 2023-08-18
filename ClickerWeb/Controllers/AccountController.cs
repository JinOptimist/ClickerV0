using ClickerWeb.DAL.Models;
using ClickerWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClickerWeb.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthUserViewModel viewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, false);

            if (!result.Succeeded)
            {
                return View(viewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AuthUserViewModel authUserView)
        {
            if (!ModelState.IsValid)
            {
                return View(authUserView);
            }

            var user = new User
            {
                Email = authUserView.Email,
                UserName = authUserView.Email,
            };

            var result = await _userManager.CreateAsync(user, authUserView.Password);
            if (!result.Succeeded)
            {
                return View(authUserView);
            }

            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
