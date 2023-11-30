namespace Negotation.Domain.Exceptions;

public sealed class NegotiationAttemptBiggerThanMaxException : BaseException
{
    public NegotiationAttemptBiggerThanMaxException(int maxAttempt, int providedAttempt) 
        : base($"Your attempt: {providedAttempt} reached max attempt value ({maxAttempt})")
    {
    }
}
