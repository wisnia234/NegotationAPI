
using Microsoft.EntityFrameworkCore;
using Negotation.Application.Abstractions;
using Negotation.Application.DTO;
using Negotation.Application.Queries;
using Negotation.Domain.Entities;
using Negotation.Infrastructure.DAL;
using Negotation.Infrastructure.Extensions;
using Negotation.Domain.ValueObjects;

namespace Negotation.Infrastructure.Handlers;

internal sealed class GetProductsByIdHandler : IQueryHandler<GetProductById, ProductDto>
{
    private readonly DbSet<Product> _products;

    public GetProductsByIdHandler(ApplicationDbContext dbContext)
    {
        _products = dbContext.Products;
    }

    public async Task<ProductDto> HandleAsync(GetProductById query)
    {
        ProductId productId = query.ProductId;
        Product product = await _products
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == productId);

        return product?.ToDTO();
    }
       
   
}
