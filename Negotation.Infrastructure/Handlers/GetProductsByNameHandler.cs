using Microsoft.EntityFrameworkCore;
using Negotation.Application.Abstractions;
using Negotation.Application.DTO;
using Negotation.Application.Queries;
using Negotation.Domain.Entities;
using Negotation.Domain.ValueObjects;
using Negotation.Infrastructure.DAL;
using Negotation.Infrastructure.Extensions;

namespace Negotation.Infrastructure.Handlers;

internal class GetProductsByNameHandler : IQueryHandler<GetProductByName, ProductDto>
{
    private readonly DbSet<Product> _products;

    public GetProductsByNameHandler(ApplicationDbContext dbContext)
    {
        _products = dbContext.Products;
    }
    public async Task<ProductDto> HandleAsync(GetProductByName query)
    {
        ProductName productName = query.ProductName;
        Product product = await _products
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Name == productName);

        return product?.ToDTO();
    }
}
