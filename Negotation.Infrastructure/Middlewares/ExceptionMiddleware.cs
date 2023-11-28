using Microsoft.AspNetCore.Http;
using Negotation.Domain.Exceptions;
using System.Text.Json;

namespace Negotation.Infrastructure.Exceptions;

public class ExceptionMiddleware : IMiddleware
{

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(exception, context);
        }
    }

    private async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        var (statusCode, error) = exception switch
        {
            BaseException => (StatusCodes.Status400BadRequest, exception.Message),
            _ => (StatusCodes.Status500InternalServerError, "There was an internal error.")
        };

        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        string json = JsonSerializer.Serialize(error);
        await context.Response.WriteAsync(json);
    }

}
