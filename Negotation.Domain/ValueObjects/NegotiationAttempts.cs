using Negotation.Domain.Exceptions;

namespace Negotation.Domain.ValueObjects;

public record NegotiationAttempts
{
    public int Value { get; set; }

    private const int maxAttempts = 3;

    public NegotiationAttempts(int value)
    {
        if(value <= 0)
        {
            throw new NegotiationAttemptLessOrEqualZero(value);
        }

        if(value > maxAttempts) 
        {
            throw new NegotiationAttemptBiggerThanMaxException(maxAttempts, value);
        }

        Value = value;
    }

    public static implicit operator NegotiationAttempts(int attempts) => new(attempts);

    public static implicit operator int(NegotiationAttempts attempts) => attempts.Value;
}
