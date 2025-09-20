
using ContaBancaria.Data;
using Microsoft.EntityFrameworkCore;

namespace ContaBancaria.Extensions
{
    public static class ContextExtensions
    {
        public static void DataContextConfigurations(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}