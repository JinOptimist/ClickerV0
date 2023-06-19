using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public class Startup
    {
        public void RegisterDbContext(IServiceCollection services)
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ClickerV0;Trusted_Connection=True;";
            services.AddDbContext<WebContext>(op => op.UseSqlServer(connectionString));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            RegisterDbContext(services);
        }
    }
}
