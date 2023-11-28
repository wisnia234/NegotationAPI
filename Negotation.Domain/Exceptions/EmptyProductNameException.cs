namespace Negotation.Domain.Exceptions;

public class EmptyProductNameException : BaseException
{
    public EmptyProductNameException() : base("Product name cannot be null or empty")
    {
    }
}
