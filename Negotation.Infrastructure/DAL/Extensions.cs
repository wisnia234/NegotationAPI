using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Negotation.Infrastructure.DbInitializer;

namespace Negotation.Infrastructure.DAL;

internal static class Extensions
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
            x => x.MigrationsAssembly("Negotation.Infrastructure")));

        services.AddHostedService<ApplicationDbInitializer>();

        return services;
    }
}
