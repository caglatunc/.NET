using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace CleanArchitecture.WebAPI.Middlewares;

public sealed class ExceptionMiddleware : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = 500;
        httpContext.Response.ContentType = "application/json";

        if(exception.GetType() == typeof(ValidationException))
        {
            httpContext.Response.StatusCode = 409;
        }

        var responseObject = new
        {
            ErrorMessage = exception.Message,
        };
        //Objeyi stringe çevirme işlemi
        string responseString = JsonSerializer.Serialize(responseObject);

        await httpContext.Response.WriteAsync(responseString);

        return true;
    }
}
