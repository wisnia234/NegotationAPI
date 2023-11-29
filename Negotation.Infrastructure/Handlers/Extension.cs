using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Negotation.Application.Abstractions;
using System.Reflection;

namespace Negotation.Infrastructure.Handlers;

internal static class Extension
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        var infrastructureAssembly = Assembly.Load("Negotation.Infrastructure");

        services.Scan(s => s.FromAssemblies(infrastructureAssembly)
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        return services;
    }
}
