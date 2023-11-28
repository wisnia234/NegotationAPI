using Negotation.Application.Abstractions;
using Negotation.Application.Commands;
using Negotation.Domain.Entities;
using Negotation.Domain.Repositories;

namespace Negotation.Application.Handlers;

internal sealed class AddProductHandler : ICommandHandler<AddProduct>
{
    private readonly IProductRepository _productRepository;

    public AddProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task HandleAsync(AddProduct command)
    {
        Product product = new()
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Price = command.Price,
        };

        await _productRepository.AddAsync(product);
    }
}
