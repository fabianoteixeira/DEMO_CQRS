﻿using DemoCQRS.Application.AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DemoCQRS.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
            services.AddAutoMapper(typeof(DTOToCommandMappingProfile));
            services.AddAutoMapper(typeof(DomainToEventMappingProfile));

            return services;
        }
    }
}
