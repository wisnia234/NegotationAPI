using Negotation.Domain.Exceptions;
using System;


namespace Negotation.Domain.ValueObjects;

public sealed record NegotiationId
{
    public Guid Value { get; set; }

    public NegotiationId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyIdException("Negotiation Id cannot be null or empty");
        }

        Value = value;
    }

    public static implicit operator Guid(NegotiationId negotiationId) => negotiationId.Value;

    public static implicit operator NegotiationId(Guid negotiationId) => new(negotiationId);

    public override string ToString() => Value.ToString("N");
}
