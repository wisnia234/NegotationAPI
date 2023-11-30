using Microsoft.Extensions.DependencyInjection;
using Negotation.Application.Abstractions;
using Negotation.Domain.Repositories;
using Negotation.Infrastructure.Decorators;
using Negotation.Infrastructure.UnitOfWork;

namespace Negotation.Infrastructure.Repositories;

internal static class Extensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork, DbUnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<INegotiationRepository, NegotiationRepository>();

        services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));
        return services;
    }


}
