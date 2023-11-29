using Negotation.Domain.Exceptions;
using System;

namespace Negotation.Domain.ValueObjects;

public sealed record UserId
{
    public Guid Value {  get; set; }

    public UserId(Guid value)
    {
        if(Guid.Empty == value)
        {
            throw new EmptyIdException("User Id cannot be null or empty");
        }

        Value = value;
    }

    public static implicit operator Guid(UserId userId) => userId.Value;

    public static implicit operator UserId(Guid userId) => new(userId);
}
