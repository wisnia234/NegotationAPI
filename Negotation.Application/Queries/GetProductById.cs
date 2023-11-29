
using Negotation.Application.Abstractions;
using Negotation.Application.DTO;

namespace Negotation.Application.Queries;

public sealed class GetProductById : IQuery<ProductDto>
{
    public Guid ProductId { get; set; }
}
