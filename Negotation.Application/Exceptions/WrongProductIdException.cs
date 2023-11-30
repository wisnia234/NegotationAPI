using Negotation.Domain.Exceptions;

namespace Negotation.Application.Exceptions;

public sealed class WrongProductIdException : BaseException
{
    public WrongProductIdException(string exceptionMessage) : base($"Provided product id: {exceptionMessage} does not match to any of products")
    {
    }
}
