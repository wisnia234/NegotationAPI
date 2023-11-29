using Negotation.Application.Abstractions;
using Negotation.Application.DTO;


namespace Negotation.Application.Queries;

public sealed class GetProductByName : IQuery<ProductDto>
{
    public string ProductName { get; set; }
}
