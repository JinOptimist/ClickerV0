using ClickerWeb.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClickerWeb.DAL
{
    public class WebContext : IdentityDbContext<User>
    {
        public WebContext(DbContextOptions<WebContext> option) : base(option) { }
    }
}
