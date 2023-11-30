using Negotation.Domain.Exceptions;

namespace Negotation.Application.Exceptions;

public sealed class BlockedNegotiationException : BaseException
{
    public BlockedNegotiationException() : base("This transaction has blocked status")
    {
    }
}
