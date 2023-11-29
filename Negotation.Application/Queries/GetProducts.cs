using Negotation.Application.Abstractions;
using Negotation.Application.DTO;

namespace Negotation.Application.Queries;

public sealed class GetProducts : IQuery<IEnumerable<ProductDto>>
{
}
