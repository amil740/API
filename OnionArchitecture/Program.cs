
using OnionArchitecture.Application;
using OnionArchitecture.Application.Common.Middleware;
using OnionArchitecture.Persistancee;

namespace OnionArchitecture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            // Add Application layer services (AutoMapper, Services)
            builder.Services.AddApplicationServices();

            // Add Persistence layer services (DbContext)
            builder.Services.AddPersistenceServices(builder.Configuration);

            var app = builder.Build();

            // Global Exception Handling Middleware
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
