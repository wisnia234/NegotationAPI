using Negotation.Application.Abstractions;
namespace Negotation.Application.Commands;

public sealed record UpdateNegotiationForClient(Guid NegotiationId) : ICommand;
