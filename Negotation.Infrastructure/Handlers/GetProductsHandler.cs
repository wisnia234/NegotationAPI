using Microsoft.EntityFrameworkCore;
using Negotation.Application.Abstractions;
using Negotation.Application.DTO;
using Negotation.Application.Queries;
using Negotation.Domain.Entities;
using Negotation.Infrastructure.DAL;
using Negotation.Infrastructure.Extensions;

namespace Negotation.Infrastructure.Handlers;

internal sealed class GetProductsHandler : IQueryHandler<GetProducts, IEnumerable<ProductDto>>
{

    private readonly DbSet<Product> _products;

    public GetProductsHandler(ApplicationDbContext dbContext)
    {
        _products = dbContext.Products;
    }
    public async Task<IEnumerable<ProductDto>> HandleAsync(GetProducts query)
        => await _products
            .AsNoTracking()
            .Select(x => x.ToDTO())
            .ToListAsync();
    
}
