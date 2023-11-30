using Negotation.Application.Abstractions;

namespace Negotation.Application.Commands;

public sealed record RemoveNegotiationById(Guid NegotiationId) : ICommand;

