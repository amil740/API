using OnionArchitecture.Application.Common.Models;
using System.Text.Json;

namespace OnionArchitecture.Middleware;

public class GlobalExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            ApiResponse<bool> response = ApiResponse<bool>.FailureResult(ex.Message);
            context.Response.ContentType = "application/json";
            var serialized = JsonSerializer.Serialize(response);
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync(serialized);
        }
    }
}
