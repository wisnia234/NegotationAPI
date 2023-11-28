using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Negotation.Infrastructure.DAL;
using Negotation.Infrastructure.Middlewares;
using Negotation.Infrastructure.Repositories;

namespace Negotation.Infrastructure.Extensions;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataAccessLayer(configuration);
        services.AddRepositories();
        services.AddMiddleware();

        return services;
    }
}
