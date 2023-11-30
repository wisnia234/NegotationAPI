using Negotation.Domain.Exceptions;

namespace Negotation.Application.Exceptions;

public sealed class WrongUserIdException : BaseException
{
    public WrongUserIdException(string exceptionMessage) : base($"Provided user id:{exceptionMessage} does not match to any of users")
    {
    }
}
