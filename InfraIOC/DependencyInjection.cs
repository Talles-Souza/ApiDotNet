﻿using Application.Service.Interface;
using Application.Service;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.Repositories;
using Domain.Repositories;
using Application.Mapping;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Microsoft.Extensions.Hosting;
using MySqlConnector;

namespace IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastruture(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment environment)
        {

            services.AddDbContext<MySqlContext>(options =>
            options.UseMySql
            ("server=localhost; database=dotnet;Uid=root;pwd=dias0502",
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")));
            services.AddMvc();
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IPersonService, PersonService>();
            return services;

        }



    }
}
