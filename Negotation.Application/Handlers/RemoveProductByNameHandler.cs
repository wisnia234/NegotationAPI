using Negotation.Application.Abstractions;
using Negotation.Application.Commands;
using Negotation.Domain.Repositories;

namespace Negotation.Application.Handlers;

internal class RemoveProductByNameHandler : ICommandHandler<RemoveProductByName>
{
    private readonly IProductRepository _repository;

    public RemoveProductByNameHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(RemoveProductByName command)
    {
        await _repository.RemoveByNameAsync(command.Name);
    }
}
