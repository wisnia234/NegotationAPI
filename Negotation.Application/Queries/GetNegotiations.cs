using Negotation.Application.Abstractions;
using Negotation.Domain.Entities;

namespace Negotation.Application.Queries;

public sealed class GetNegotiations : IQuery<IEnumerable<Negotiation>>
{
}
