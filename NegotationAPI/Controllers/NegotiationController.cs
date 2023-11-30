using Negotation.Application.Abstractions;
using Negotation.Application.Commands;

namespace NegotationAPI.Controllers;

internal static class NegotiationController
{
    public static WebApplication UseNegotiationEndpoints(this WebApplication app)
    {
        app.MapPost("negotiations/createNegotiation", async (AddNegotiation command, ICommandHandler<AddNegotiation> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.NoContent();
        });

        app.MapPut("negotiations/repeatNegotiation", 
            async (UpdateNegotiationForClient command, ICommandHandler<UpdateNegotiationForClient> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.NoContent();
        });

        app.MapPut("negotiations/verifyNegotiation", 
            async (UpdateNegotiationForEmployee command, ICommandHandler<UpdateNegotiationForEmployee> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.NoContent();
        });

        return app;
    }
}
