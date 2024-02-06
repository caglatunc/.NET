
namespace ExceptionHandler.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    //4
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError; ;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(new ErrorResult(ex.Message).ToString());
        }
    }
}
