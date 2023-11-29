using Negotation.Application.Abstractions;
using Negotation.Application.Commands;

namespace NegotationAPI.Controllers;

internal static class UserController
{
    public static WebApplication UseUserEndpoints(this WebApplication app)
    {           

        app.MapPost("users/add", async (AddUser command, ICommandHandler<AddUser> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.NoContent();
        });

       
        return app;
    }
}
