using Negotation.Domain.Exceptions;

namespace Negotation.Domain.ValueObjects;

public sealed record NegotiationPrice
{
    public decimal Value { get; set; }

    public NegotiationPrice(decimal value)
    {
        if(value < 0)
        {
            throw new PriceIsLessThanZeroException(value.ToString());
        }

        Value = value;
    }

    public static implicit operator decimal(NegotiationPrice negotiationPrice) => negotiationPrice.Value;

    public static implicit operator NegotiationPrice(decimal negotiationPrice) => new(negotiationPrice);

    public override string ToString() => Value.ToString();

}
