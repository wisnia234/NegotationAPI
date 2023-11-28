namespace Negotation.Domain.Exceptions;

public abstract class BaseException : Exception
{
    protected BaseException(string exceptionMessage) : base(exceptionMessage) 
    {
        
    }
}
