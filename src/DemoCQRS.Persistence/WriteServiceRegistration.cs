using DemoCQRS.Application.Contracts.Write;
using DemoCQRS.Write.Context;
using DemoCQRS.Write.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DemoCQRS.Write
{
    public static class WriteServiceRegistration
    {
        public static IServiceCollection AddWriteServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WriteDbContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IPersonWriteRepository, PersonWriteRepository>();

            return services;
        }
    }
}
