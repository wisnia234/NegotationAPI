using Negotation.Application.Abstractions;
using Negotation.Application.Commands;
using Negotation.Application.Exceptions;
using Negotation.Domain.Repositories;

namespace Negotation.Application.Handlers;

internal sealed class RemoveProductByNameHandler : ICommandHandler<RemoveProductByName>
{
    private readonly IProductRepository _repository;

    public RemoveProductByNameHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task HandleAsync(RemoveProductByName command)
    {
        var product = await _repository.GetByNameAsync(command.Name);

        if (product is null)
        {
            throw new ProductByIdNameNullException(command.Name);
        }

        await _repository.RemoveByNameAsync(command.Name);
    }
}
