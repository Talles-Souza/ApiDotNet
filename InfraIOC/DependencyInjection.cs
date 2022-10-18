using Application.Service.Interface;
using Application.Service;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.Repositories;
using Domain.Repositories;

namespace IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MySqlContext>(options => 
            options.UseMySql
            ("server=localhost; database=dotnet;uid=root;pwd=dias0502", 
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")));
            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPersonService, PersonService>();
            return services;

        }
    }
}
