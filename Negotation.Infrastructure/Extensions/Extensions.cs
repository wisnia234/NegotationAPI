using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Negotation.Application.DTO;
using Negotation.Domain.Entities;
using Negotation.Infrastructure.DAL;
using Negotation.Infrastructure.Handlers;
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
        services.AddHandlers();

        return services;
    }

    public static ProductDto ToDTO(this Product product) => new()
    {
        Name = product.Name,
        Price = product.Price,
    };


}
