using Microsoft.AspNetCore.Mvc;
using Negotation.Application.Abstractions;
using Negotation.Application.Commands;
using Negotation.Application.DTO;
using Negotation.Application.Queries;

namespace NegotationAPI.Controllers;

public static class ProductController
{
    public static WebApplication UseProductEndpoints(this WebApplication app)
    {
        app.MapGet("products/get", async (IQueryHandler<GetProducts, IEnumerable<ProductDto>> handler) =>
        {
            GetProducts query = new();
            var products = await handler.HandleAsync(query);
            return Results.Ok(products);
        });

        app.MapGet("products/get/{productId:guid}", async (Guid productId, IQueryHandler<GetProductById, ProductDto> handler) =>
        {
            GetProductById query = new()
            {
                ProductId = productId,
            };
            var product = await handler.HandleAsync(query);
            return Results.Ok(product);
        });

        app.MapGet("products/get/{productName}", async (string productName, IQueryHandler<GetProductByName, ProductDto> handler) =>
        {
            GetProductByName query = new()
            {
                ProductName = productName,
            };
            var product = await handler.HandleAsync(query);
            return Results.Ok(product);
        });

        app.MapPost("products/add", async (AddProduct command, ICommandHandler<AddProduct> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.NoContent();
        });

        app.MapDelete("products/removeById", async ([FromBody] RemoveProductById command, ICommandHandler<RemoveProductById> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.NoContent();
        });

        app.MapDelete("products/removeByName", async ([FromBody] RemoveProductByName command, ICommandHandler<RemoveProductByName> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.NoContent();
        });
        return app;
    }
}
