using DemoCQRS.Application.Contracts;
using DemoCQRS.Application.Contracts.Write;
using DemoCQRS.Read.Repositories;
using DemoCQRS.Write.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DemoCQRS.Read
{
    public static class ReadServiceRegistration
    {
        public static IServiceCollection AddReadServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IPersonReadRepository, PersonReadRepository>();
            return services;
        }
    }
}
