using ClickerWeb.DAL.Models;
using ClickerWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClickerWeb.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
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

            return RedirectToAction("Index", "Home");
        }
    }
}
