
using OnionArchitecture.Application;
using OnionArchitecture.Middleware;
using OnionArchitecture.Persistancee;
using Scalar.AspNetCore;

namespace OnionArchitecture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            builder.Services.AddApplicationServices();

            builder.Services.AddPersistenceServices(builder.Configuration);

            var app = builder.Build();

            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
