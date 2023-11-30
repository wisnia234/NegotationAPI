using Negotation.Domain.Exceptions;

namespace Negotation.Application.Exceptions;

public sealed class AcceptedNegotationException : BaseException
{
    public AcceptedNegotationException() : base("This transaction is accepted and cannot be repeat again")
    {
    }
}
