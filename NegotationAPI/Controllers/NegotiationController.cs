using Microsoft.AspNetCore.Mvc;
using Negotation.Application.Abstractions;
using Negotation.Application.Commands;
using Negotation.Application.Queries;
using Negotation.Domain.Entities;

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

        app.MapDelete("negotiations/delete", async ([FromBody] RemoveNegotiationById command, ICommandHandler<RemoveNegotiationById> handler) =>
        {
            await handler.HandleAsync(command);
            return Results.NoContent();
        });

        app.MapGet("negotiations/get", async (IQueryHandler<GetNegotiations, IEnumerable<Negotiation>> handler) =>
        {
            GetNegotiations query = new();
            var result = await handler.HandleAsync(query);

            return Results.Ok(result);

        });

        return app;
    }
}
