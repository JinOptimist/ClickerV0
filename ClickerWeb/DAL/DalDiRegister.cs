using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClickerWeb.DAL
{
    public class DalDiRegister
    {
        public void RegisterDbContext(IServiceCollection services)
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ClickerV0;Trusted_Connection=True;";
            services
                .AddDbContext<WebContext>(option =>
                    option
                        .UseLazyLoadingProxies(true)
                        .UseSqlServer(connectionString));
        }
    }
}
