namespace ExceptionHandler.Middlewares;

public static class ExceptionExtensions
{
    //5
    public static IApplicationBuilder UseException(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        return app;
    }
}
