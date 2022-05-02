using Jap_Task4.Database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jap_Task4.Api.Extensions
{
    public static class DatabaseExtension
    {
        public static void SetupDatabase(
            this IServiceCollection services,
            IConfiguration Configuration
        )
        {
            services.AddDbContext<DataContext>(
                options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
        }
    }
}