namespace OnionArchitecture.Application.Common.Exceptions
{
    public class AppException : Exception
    {
        public int StatusCode { get; }
        public List<string>? Errors { get; }

        public AppException(string message, int statusCode = 400, List<string>? errors = null)
            : base(message)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
    }

    public class NotFoundException : AppException
    {
        public NotFoundException(string message) : base(message, 404) { }
        public NotFoundException(string entityName, object key) 
            : base($"{entityName} with key '{key}' was not found.", 404) { }
    }

    public class BadRequestException : AppException
    {
        public BadRequestException(string message) : base(message, 400) { }
        public BadRequestException(string message, List<string> errors) : base(message, 400, errors) { }
    }

    public class UnauthorizedException : AppException
    {
        public UnauthorizedException(string message = "Unauthorized access") : base(message, 401) { }
    }

    public class ForbiddenException : AppException
    {
        public ForbiddenException(string message = "Access forbidden") : base(message, 403) { }
    }

    public class ConflictException : AppException
    {
        public ConflictException(string message) : base(message, 409) { }
    }

    public class ValidationException : AppException
    {
        public ValidationException(List<string> errors) 
            : base("One or more validation errors occurred.", 422, errors) { }
        
        public ValidationException(string error) 
            : base("Validation error occurred.", 422, [error]) { }
    }
}
