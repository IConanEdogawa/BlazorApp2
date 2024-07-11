using Microsoft.EntityFrameworkCore;
using TimerService.API.Abstractions;
using TimerService.API.Persistance;

namespace TimerService.API
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IAppDbContext, AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;

        }
    }
}
