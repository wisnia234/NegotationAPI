using Negotation.Domain.ValueObjects;

namespace Negotation.Domain.Entities;

public class Negotiation
{
    public NegotiationId Id { get; set; }
    public NegotiationPrice ProposedPrice { get; set; }

    public ProductId ProductId { get; set; }
    public Product Product { get; set; }

    public UserId UserId { get; set; }
    public User User { get; set; }

    public string? Comment { get; set; }
}
