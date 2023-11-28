using Microsoft.AspNetCore.Http;
using Negotation.Domain.Exceptions;
using System;
using System.Threading.Tasks;

namespace Negotation.Infrastructure.Exceptions;

internal class ExceptionMiddleware : IMiddleware
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
        await context.Response.WriteAsync(error);
    }

}
