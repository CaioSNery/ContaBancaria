

using ContaBancaria.Repositories;
using ContaBancaria.Shared.Repository;

namespace ContaBancaria.Extensions
{
    public static class RepositoriesExtensions
    {
        public static void RepositoriesConfigurations(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();
        }
    }
}