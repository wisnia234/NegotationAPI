using Negotation.Application.Abstractions;
using Negotation.Application.Commands;
using Negotation.Domain.Repositories;

namespace Negotation.Application.Handlers;

internal class RemoveProductByIdHandler : ICommandHandler<RemoveProductById>
{
    private readonly IProductRepository _repository;

    public RemoveProductByIdHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(RemoveProductById command)
    {
        await _repository.RemoveByIdAsync(command.Id);
    }
}
