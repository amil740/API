using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Mapping;
using OnionArchitecture.Application.Services.Implementations;
using OnionArchitecture.Application.Services.Interfaces;

namespace OnionArchitecture.Application
{
    public static class ServiceRegistration
    {
        extension(IServiceCollection services)
        {
            public void AddApplicationServices()
            {
                // AutoMapper
                services.AddAutoMapper(typeof(MappingProfile).Assembly);

                // Services
                services.AddScoped<ICategoryService, CategoryService>();
            }
        }
    }
}
