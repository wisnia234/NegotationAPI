using Negotation.Application.Abstractions;
using Negotation.Application.Commands;
using Negotation.Application.Exceptions;
using Negotation.Domain.Entities;
using Negotation.Domain.Entities.Utils;
using Negotation.Domain.Repositories;
using Negotation.Domain.ValueObjects;

namespace Negotation.Application.Handlers;

internal sealed class UpdateNegotiationForClientHandler : ICommandHandler<UpdateNegotiationForClient>
{

    private readonly INegotiationRepository _negotiationRepository;

    public UpdateNegotiationForClientHandler(INegotiationRepository negotiationRepository)
    {
        _negotiationRepository = negotiationRepository;
    }

    public async Task HandleAsync(UpdateNegotiationForClient command)
    {
        Negotiation negotiation = await _negotiationRepository.GetByIdAsync(command.NegotiationId);

        ValidateHandleAsync(negotiation);

        int attempts = negotiation.Attempts;
        negotiation.Attempts = new NegotiationAttempts(attempts + 1);
        negotiation.Status = Status.Considered;

        await _negotiationRepository.UpdateAsync(negotiation);
    }

    private void ValidateHandleAsync(Negotiation negotiation)
    {
        if (negotiation is null)
        {
            throw new NegotiationNotFoundException();
        }

        if (negotiation.Status == Status.Blocked)
        {
            throw new BlockedNegotiationException();
        }

        if (negotiation.Status == Status.Accepted)
        {
            throw new AcceptedNegotationException();
        }

        if (negotiation.Status == Status.Considered)
        {
            throw new ConsideredStatusException();
        }
    }
}
