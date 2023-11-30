using Negotation.Domain.Exceptions;

namespace Negotation.Application.Exceptions;

public sealed class NegotiationNotFoundException : BaseException
{
    public NegotiationNotFoundException() : base("Negotiation does not exist")
    {
    }
}
