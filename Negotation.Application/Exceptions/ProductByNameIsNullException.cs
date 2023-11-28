using Negotation.Domain.Exceptions;

namespace Negotation.Application.Exceptions;

public class ProductByIdNameNullException : BaseException
{
    public ProductByIdNameNullException(string exceptionMessage) : base($"Provided name {exceptionMessage} does not belong to any of products")
    {
    }
}
