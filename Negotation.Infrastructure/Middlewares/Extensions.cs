using Microsoft.Extensions.DependencyInjection;
using Negotation.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Negotation.Infrastructure.Middlewares;

internal static class Extensions
{
    public static IServiceCollection AddMiddleware(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionMiddleware>();

        return services;
    }

}
