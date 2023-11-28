namespace Negotation.Domain.Exceptions;

public sealed class EmptyProductIdException : BaseException
{
    public EmptyProductIdException() : base("Product Id cannot be null")
    {
    }
}
