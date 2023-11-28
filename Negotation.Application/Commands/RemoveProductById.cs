using Negotation.Application.Abstractions;

namespace Negotation.Application.Commands;

public record RemoveProductById(Guid Id) : ICommand;

