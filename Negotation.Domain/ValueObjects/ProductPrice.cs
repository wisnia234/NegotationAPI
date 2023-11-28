using Negotation.Domain.Exceptions;

namespace Negotation.Domain.ValueObjects;

public sealed record ProductPrice
{
    public decimal Value { get; set; }

    public ProductPrice(decimal value)
    {
        if(value < 0)
        {
            throw new PriceIsLessThanZeroException(value.ToString());
        }

        Value = value;
    }

    public static implicit operator decimal(ProductPrice productPrice) => productPrice.Value;

    public static implicit operator ProductPrice(decimal productPrice) => new(productPrice);

    public override string ToString() => Value.ToString();
}
