using Negotation.Domain.Entities;
using Negotation.Domain.ValueObjects;
using System.Threading.Tasks;

namespace Negotation.Domain.Repositories;

public interface INegotiationRepository
{
    Task AddAsync(Negotiation negotiation);
    Task DeleteAsync(Negotiation negotiation);
    Task<Negotiation> GetByIdAsync(NegotiationId negotiationId);
    Task UpdateAsync(Negotiation negotiation);

}
