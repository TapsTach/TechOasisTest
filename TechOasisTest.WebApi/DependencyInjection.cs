using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechOasisTest.WebApi.Services;

namespace TechOasisTest.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<SeedingServices>();
            services.AddScoped<ProfileServices>();
            return services;
        }
    }
}
