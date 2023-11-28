using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Negotation.Domain.Entities;
using Negotation.Domain.ValueObjects;
using Negotation.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Negotation.Infrastructure.DbInitializer;

internal sealed class ApplicationDbInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public ApplicationDbInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await dbContext.Database.MigrateAsync(cancellationToken);

        if (await dbContext.Products.AnyAsync(cancellationToken))
        {
            return;
        }

        var products = new List<Product>
        {
            new Product() {Id =  Guid.NewGuid(), Name = "Product 1", Price = 30},
            new Product() {Id =  Guid.NewGuid(), Name = "Product 2", Price = 110},
            new Product() {Id =  Guid.NewGuid(), Name = "Product 3", Price = 10}
        };

        await dbContext.Products.AddRangeAsync(products, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    
}
