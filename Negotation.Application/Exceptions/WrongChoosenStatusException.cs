using Negotation.Domain.Exceptions;

namespace Negotation.Application.Exceptions;

public sealed class WrongChoosenStatusException : BaseException
{
    public WrongChoosenStatusException(string exceptionMessage) : base(exceptionMessage)
    {
    }
}
