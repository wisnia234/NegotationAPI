using Negotation.Domain.Exceptions;

namespace Negotation.Application.Exceptions;

public sealed class ConsideredStatusException : BaseException
{
    public ConsideredStatusException() : base("This transaction is being considered. Please be patient.")
    {
    }
}
