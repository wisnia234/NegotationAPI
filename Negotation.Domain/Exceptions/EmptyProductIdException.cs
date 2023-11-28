namespace Negotation.Domain.Exceptions;

public class EmptyProductIdException : BaseException
{
    public EmptyProductIdException() : base("Product Id cannot be null")
    {
    }
}
