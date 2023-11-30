using Microsoft.EntityFrameworkCore;
using Negotation.Domain.Entities;
using Negotation.Domain.Repositories;
using Negotation.Domain.ValueObjects;
using Negotation.Infrastructure.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negotation.Infrastructure.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly DbSet<Product> _products;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _products = dbContext.Products;
    }

    public async Task AddAsync(Product product)
    {
        await _products.AddAsync(product);
    }

    public async Task<Product> GetByIdAsync(ProductId productId)
        => await _products
        .SingleOrDefaultAsync(x => x.Id == productId);

    public async Task<Product> GetByNameAsync(ProductName name)
        => await _products
        .SingleOrDefaultAsync(x => x.Name == name);

    public async Task RemoveByIdAsync(ProductId productId)
    {
       Product product = await _products
            .SingleOrDefaultAsync(x => x.Id == productId);

       _products.Remove(product);
    }

    public async Task RemoveByNameAsync(ProductName productName)
    {
        Product product = await _products
            .SingleOrDefaultAsync(x => x.Name == productName);
        _products.Remove(product);
    }
}
