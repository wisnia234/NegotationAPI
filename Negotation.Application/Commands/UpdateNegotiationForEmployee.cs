using Negotation.Application.Abstractions;
using Negotation.Domain.Entities.Utils;

namespace Negotation.Application.Commands;

public sealed record UpdateNegotiationForEmployee(Guid NegotiationId, Status Status) : ICommand;

