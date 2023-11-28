﻿using Negotation.Domain.Entities;
using Negotation.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Negotation.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(ProductId productId);
    Task<Product> GetByNameAsync(ProductName name);
    Task AddAsync(Product product);
}
