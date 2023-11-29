using Negotation.Domain.Exceptions;


namespace Negotation.Domain.ValueObjects;

public sealed record UserName
{
    public string Value { get; set; }

    public UserName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyProductNameException();
        }

        Value = value;
    }

    public static implicit operator string(UserName userName) => userName.Value;

    public static implicit operator UserName(string userName) => new(userName);

    public override string ToString() => Value;
}
