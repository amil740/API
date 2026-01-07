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
                services.AddAutoMapper(typeof(MappingProfile).Assembly);

                services.AddScoped<ICategoryService, CategoryService>();
                services.AddScoped<IProductService, ProductService>();
            }
        }
    }
}
