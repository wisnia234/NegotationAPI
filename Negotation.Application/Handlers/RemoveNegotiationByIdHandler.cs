using Negotation.Application.Abstractions;
using Negotation.Application.Commands;
using Negotation.Application.Exceptions;
using Negotation.Domain.Entities;
using Negotation.Domain.Repositories;

namespace Negotation.Application.Handlers;

internal sealed class RemoveNegotiationByIdHandler : ICommandHandler<RemoveNegotiationById>
{
    private readonly INegotiationRepository _negotiations;

    public RemoveNegotiationByIdHandler(INegotiationRepository negotiations)
    {
        _negotiations = negotiations;
    }

    public async Task HandleAsync(RemoveNegotiationById command)
    {
        Negotiation negotiation = await _negotiations.GetByIdAsync(command.NegotiationId);

        if (negotiation is null)
        {
            throw new ProductByIdIsNullException(command.NegotiationId.ToString());
        }

        await _negotiations.DeleteAsync(negotiation);
    }
}
