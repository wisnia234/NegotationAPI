using Negotation.Application.Abstractions;


namespace Negotation.Application.Commands;

public sealed record AddNegotiation(Guid ProductId, Guid UserId, decimal ProposedPrice, string? Comment) : ICommand;
