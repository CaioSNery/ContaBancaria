using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContaBancaria.Services;
using ContaBancaria.Shared.Services;

namespace ContaBancaria.Extensions
{
    public static class ServicesExtensions
    {
        public static void ServicesConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IContaService, ContaService>();
        }
    }
}