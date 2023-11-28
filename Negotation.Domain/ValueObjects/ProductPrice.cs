namespace Negotation.Domain.ValueObjects;

internal sealed record ProductPrice
{
    public decimal Value { get; set; }

    public ProductPrice(decimal value)
    {
        if(value < 0)
        {

        }

        Value = value;
    }

    public static implicit operator decimal(ProductPrice productName) => productName.Value;

    public static implicit operator ProductPrice(decimal productName) => new(productName);

    public override string ToString() => Value.ToString();
}
