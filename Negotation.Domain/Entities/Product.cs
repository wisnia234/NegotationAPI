using Negotation.Domain.ValueObjects;

namespace Negotation.Domain.Entities;

public class Product
{
    public ProductId Id { get; set; }
    public ProductName Name { get; set; } 
}
