using ClickerWeb.DAL;
using ClickerWeb.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace ClickerWeb.MiddlewareServices
{
    public class LoginFromTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginFromTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var isCorsCall = context.Request.Host.Value != new Uri(context.Request.Headers.Origin[0] ?? "")?.Authority;
            var isLoginRequest = false; //context.Request.RouteValues["controller"] == "Account";
            
            if (isCorsCall && !isLoginRequest)
            {
                var signInManager = context.RequestServices.GetService<SignInManager<User>>();
                var userManager = context.RequestServices.GetService<UserManager<User>>();
                var id = context.Request.Headers["token"];
                var user = await userManager.FindByIdAsync(id);

                if (user == null)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.CompleteAsync();
                    return;
                }

                await signInManager.SignInAsync(user, false);
            }

            await _next(context);
        }
    }
}
