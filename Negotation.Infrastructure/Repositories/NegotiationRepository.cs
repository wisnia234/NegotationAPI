using Microsoft.EntityFrameworkCore;
using Negotation.Domain.Entities;
using Negotation.Domain.Repositories;
using Negotation.Domain.ValueObjects;
using Negotation.Infrastructure.DAL;

namespace Negotation.Infrastructure.Repositories;

internal sealed class NegotiationRepository : INegotiationRepository
{
    private readonly DbSet<Negotiation> _negotiations;

    public NegotiationRepository(ApplicationDbContext dbContext)
    {
        _negotiations = dbContext.Negotations;
    }
    public async Task AddAsync(Negotiation negotiation)
    {
        await _negotiations.AddAsync(negotiation);
    }

    public Task DeleteAsync(Negotiation negotiation)
    {
        _negotiations.Remove(negotiation);
        return Task.CompletedTask;
    }

    public async Task<Negotiation> GetByIdAsync(NegotiationId negotiationId)
        => await _negotiations
        .SingleOrDefaultAsync(x => x.Id == negotiationId);

    public Task UpdateAsync(Negotiation negotiation)
    {
        _negotiations.Update(negotiation);
        return Task.CompletedTask;
    }
}
