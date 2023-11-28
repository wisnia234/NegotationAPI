using Negotation.Application.Abstractions;
using Negotation.Application.Commands;
using Negotation.Application.Exceptions;
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
        var product = await _repository.GetByIdAsync(command.Id);

        if(product is null)
        {
            throw new ProductByIdIsNullException(command.Id.ToString());
        }

        await _repository.RemoveByIdAsync(command.Id);
    }
}
