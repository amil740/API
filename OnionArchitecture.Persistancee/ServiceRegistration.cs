using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Interfaces;
using OnionArchitecture.Persistancee.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Persistancee
{
    public static class ServiceRegistration
    {
        extension(IServiceCollection services)
        {
            public void AddPersistenceServices(IConfiguration configuration)
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

                services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            }
        }
    }
}
