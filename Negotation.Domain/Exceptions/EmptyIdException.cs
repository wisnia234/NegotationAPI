namespace Negotation.Domain.Exceptions;

public sealed class EmptyIdException : BaseException
{
    public EmptyIdException(string exceptionMessage) : base(exceptionMessage)
    {
    }
}
