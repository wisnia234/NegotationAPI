using Negotation.Application.Abstractions;

namespace Negotation.Application.Commands;

public sealed record AddUser(string userName) : ICommand;
