using Negotation.Domain.Exceptions;


namespace Negotation.Application.Exceptions;

internal class ProductByIdIsNullException : BaseException
{
    public ProductByIdIsNullException(string exceptionMessage) : base($"Provided id {exceptionMessage} does not belong to any of products")
    {
    }
}
