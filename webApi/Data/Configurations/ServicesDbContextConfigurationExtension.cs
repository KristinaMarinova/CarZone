using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CarZone.Data.Configurations
{
    public static class ServicesDbContextConfigurationExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, string appConnectionString, string logConnectionString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(appConnectionString))
                .AddDbContext<AppLogContext>(options => options.UseNpgsql(logConnectionString));
        }
    }
}
