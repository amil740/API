using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OnionArchitecture.Application.Common.Exceptions;
using OnionArchitecture.Application.Common.Models;
using System.Net;
using System.Text.Json;

namespace OnionArchitecture.Application.Common.Middleware
{
    public class GlobalExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            logger.LogError(exception, "An error occurred: {Message}", exception.Message);

            var response = context.Response;
            response.ContentType = "application/json";

            ApiResponse errorResponse;

            switch (exception)
            {
                case AppException appException:
                    response.StatusCode = appException.StatusCode;
                    errorResponse = ApiResponse.FailureResult(
                        appException.Message,
                        appException.StatusCode,
                        appException.Errors);
                    break;

                case KeyNotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorResponse = ApiResponse.FailureResult(
                        exception.Message,
                        (int)HttpStatusCode.NotFound);
                    break;

                case UnauthorizedAccessException:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    errorResponse = ApiResponse.FailureResult(
                        "Unauthorized access",
                        (int)HttpStatusCode.Unauthorized);
                    break;

                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse = ApiResponse.FailureResult(
                        "An internal server error occurred.",
                        (int)HttpStatusCode.InternalServerError);
                    break;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var result = JsonSerializer.Serialize(errorResponse, options);
            await response.WriteAsync(result);
        }
    }
}
