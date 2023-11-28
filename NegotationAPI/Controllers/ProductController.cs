using Microsoft.AspNetCore.Mvc;
using Negotation.Application.Abstractions;
using Negotation.Application.Commands;

namespace NegotationAPI.Controllers;

public static class ProductController
{
    public static WebApplication ProductEndpoints(this WebApplication app)
    {
        app.MapPost("products/add", async (AddProduct command, ICommandHandler<AddProduct> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.NoContent();
        });

        app.MapDelete("products/removeById", async ([FromBody] RemoveProductById command, [FromServices] ICommandHandler<RemoveProductById> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.NoContent();
        });

        app.MapDelete("products/removeByName", async ([FromBody] RemoveProductByName command, [FromServices] ICommandHandler<RemoveProductByName> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.NoContent();
        });
        return app;
    }
}
