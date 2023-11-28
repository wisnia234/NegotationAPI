using Negotation.Application.Abstractions;

namespace Negotation.Application.Commands;

public record RemoveProductByName(string Name) : ICommand;
