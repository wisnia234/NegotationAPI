namespace Negotation.Domain.Exceptions;

public sealed class NegotiationAttemptLessOrEqualZero : BaseException
{
    public NegotiationAttemptLessOrEqualZero(int providedAttempt) : base($"Provided attempt {providedAttempt} is lesser or equal zero")
    {
    }
}
