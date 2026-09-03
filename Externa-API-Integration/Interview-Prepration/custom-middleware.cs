/*
Custom middleware is used to implement cross-cutting concerns in the ASP.NET Core request pipeline, such as global exception handling, logging, correlation IDs, authentication-related processing, and request/response monitoring. Middleware receives HttpContext and a RequestDelegate. Calling _next(context) passes the request to the next component; logic after _next executes while the response is coming back.

*/

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Before request
        Console.WriteLine($"Request: {context.Request.Path}");

        await _next(context);

        // After request
        Console.WriteLine($"Response: {context.Response.StatusCode}");
    }
}



var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseMiddleware<LoggingMiddleware>();

app.MapControllers();

app.Run();