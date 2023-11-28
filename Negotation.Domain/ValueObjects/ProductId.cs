using Negotation.Domain.Exceptions;
using System;

namespace Negotation.Domain.ValueObjects;

public sealed record ProductId
{
    public Guid Value { get; set; }

    public ProductId(Guid value)
    {
        if(value == Guid.Empty)
        {
            throw new EmptyProductIdException();
        }

        Value = value;
    }

    public static implicit operator Guid(ProductId productId) => productId.Value;

    public static implicit operator ProductId(Guid productId) => new(productId);

    public override string ToString() => Value.ToString("N");
}
