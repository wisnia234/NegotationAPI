using Negotation.Application.Abstractions;

namespace Negotation.Application.Commands;

public record AddProduct(string Name, decimal Price) : ICommand;
