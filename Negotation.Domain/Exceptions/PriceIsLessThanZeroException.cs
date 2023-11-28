namespace Negotation.Domain.Exceptions;

public sealed class PriceIsLessThanZeroException : BaseException
{
    public PriceIsLessThanZeroException(string exceptionMessage) 
        : base($"Provided price: {exceptionMessage} must not contain a value lesser than zero")
    {
    }
}
