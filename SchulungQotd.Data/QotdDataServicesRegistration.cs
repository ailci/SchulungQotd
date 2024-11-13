using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchulungQotd.Data.Context;

namespace SchulungQotd.Data
{
    public static class QotdDataServicesRegistration
    {
        public static IServiceCollection AddQotdDataServicesRegistration(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<QotdContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
