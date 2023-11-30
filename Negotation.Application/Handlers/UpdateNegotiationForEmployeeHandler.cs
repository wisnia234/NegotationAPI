using Negotation.Application.Abstractions;
using Negotation.Application.Commands;
using Negotation.Application.Exceptions;
using Negotation.Domain.Entities;
using Negotation.Domain.Entities.Utils;
using Negotation.Domain.Repositories;

namespace Negotation.Application.Handlers;

internal sealed class UpdateNegotiationForEmployeeHandler : ICommandHandler<UpdateNegotiationForEmployee>
{
    private readonly INegotiationRepository _negotiationRepository;

    public UpdateNegotiationForEmployeeHandler(INegotiationRepository negotiationRepository)
    {
        _negotiationRepository = negotiationRepository;
    }
    public async Task HandleAsync(UpdateNegotiationForEmployee command)
    {
        Negotiation negotiation = await _negotiationRepository.GetByIdAsync(command.NegotiationId);

        if (negotiation is null)
        {
            throw new NegotiationNotFoundException();
        }

        if (command.Status == Status.Considered)
        {
            throw new WrongChoosenStatusException("Employee must choose other status than Considered");
        }

        negotiation.Status = command.Status;

        await _negotiationRepository.UpdateAsync(negotiation);

    }
}
