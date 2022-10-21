using Application.Service.Interface;
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
using Domain.Repositories.Generic;
using Data.Repositories.Generic;

namespace IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastruture(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddMvc();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IBookService, BookService>();
            return services;

        }



    }
}
