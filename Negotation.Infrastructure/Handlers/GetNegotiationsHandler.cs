using Microsoft.EntityFrameworkCore;
using Negotation.Application.Abstractions;
using Negotation.Application.Queries;
using Negotation.Domain.Entities;
using Negotation.Infrastructure.DAL;

namespace Negotation.Infrastructure.Handlers;

internal sealed class GetNegotiationsHandler : IQueryHandler<GetNegotiations, IEnumerable<Negotiation>>
{
    private readonly DbSet<Negotiation> _negotiations;

    public GetNegotiationsHandler(ApplicationDbContext dbContext)
    {
        _negotiations = dbContext.Negotations;
    }
    public async Task<IEnumerable<Negotiation>> HandleAsync(GetNegotiations query)
        => await _negotiations
        .AsNoTracking()
        .ToListAsync();

}
