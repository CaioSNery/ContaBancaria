using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContaBancaria.Extensions
{
    public static class ContextExtensions
    {
        public static void DataContextConfigurations(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<Data.AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}