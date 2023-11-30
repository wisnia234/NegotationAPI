using Negotation.Domain.Exceptions;

namespace Negotation.Application.Exceptions;

public sealed class ProposedPriceToHighException : BaseException
{
    public ProposedPriceToHighException(decimal price) : base($"The proposed price {price} cannot exceed twice the base product")
    {
    }
}
