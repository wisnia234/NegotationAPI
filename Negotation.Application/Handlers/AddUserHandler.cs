using Negotation.Application.Abstractions;
using Negotation.Application.Commands;
using Negotation.Domain.Entities;
using Negotation.Domain.Repositories;

namespace Negotation.Application.Handlers;

internal sealed class AddUserHandler : ICommandHandler<AddUser>
{
    private readonly IUserRepository _userRepository;

    public AddUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task HandleAsync(AddUser command)
    {
        User user = new()
        {
            Id = Guid.NewGuid(),
            Name = command.userName
        };

        await _userRepository.AddAsync(user);
    }
}
