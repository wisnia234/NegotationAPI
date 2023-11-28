using Negotation.Domain.Exceptions;

namespace Negotation.Domain.ValueObjects;

public sealed record ProductName
{
    public string Value { get; set; }

    public ProductName(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyProductNameException();
        }

        Value = value;
    }

    public static implicit operator string(ProductName productName) => productName.Value;

    public static implicit operator ProductName(string productName) => new(productName);

    public override string ToString() => Value;
}
