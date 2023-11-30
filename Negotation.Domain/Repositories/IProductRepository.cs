using Negotation.Domain.Entities;
using Negotation.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negotation.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(ProductId productId);
    Task<Product> GetByNameAsync(ProductName productName);
    Task AddAsync(Product product);
    Task RemoveByIdAsync(ProductId productId);
    Task RemoveByNameAsync(ProductName productName);
}
