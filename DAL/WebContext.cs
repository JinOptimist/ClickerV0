using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class WebContext : IdentityDbContext<User>
    {
        public DbSet<LevelRule> LevelRules { get; set; }

        public WebContext(DbContextOptions<WebContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        #region Way to create WebContext for Migration
        public WebContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ClickerV0;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
        #endregion
    }
}
