using Negotation.Application.Abstractions;
using Negotation.Application.Commands;
using Negotation.Application.Exceptions;
using Negotation.Domain.Entities;
using Negotation.Domain.Entities.Utils;
using Negotation.Domain.Repositories;

namespace Negotation.Application.Handlers;

internal sealed class AddNegotiationHandler : ICommandHandler<AddNegotiation>
{
    private readonly INegotiationRepository _negotiationRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;

    public AddNegotiationHandler(INegotiationRepository negotiationRepository, 
        IUserRepository userRepository, IProductRepository productRepository)
    {
        _negotiationRepository = negotiationRepository;
        _userRepository = userRepository;
        _productRepository = productRepository;
    }

    public async Task HandleAsync(AddNegotiation command)
    {
        if(await _userRepository.GetByIdAsync(command.UserId) is null)
        {
            throw new WrongUserIdException(command.UserId.ToString());
        }

        Product product = await _productRepository.GetByIdAsync(command.ProductId);

        if (product is null)
        {
            throw new WrongProductIdException(command.ProductId.ToString());
        }

        if(command.ProposedPrice > 2 * product.Price)
        {
            throw new ProposedPriceToHighException(command.ProposedPrice);
        }

        Negotiation negotiation = new()
        {
            Id = Guid.NewGuid(),
            UserId = command.UserId,
            ProductId = command.ProductId,
            Comment = command.Comment,
            Attempts = 1,
            Status = Status.Considered,
            ProposedPrice = command.ProposedPrice,
        };       

        await _negotiationRepository.AddAsync(negotiation);
    }
}
