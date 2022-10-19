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

namespace IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var connection = "server=localhost; database=dotnet;uid=root;pwd=dias0502";
            services.AddDbContext<MySqlContext>(options => 
            options.UseMySql
            ("server=localhost; database=dotnet;uid=root;pwd=dias0502", 
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")));
            services.AddApiVersioning();
            services.AddScoped<IPersonRepository, PersonRepository>();
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            if (environment.IsDevelopment())
            {
                MigrateDatabase(connection);
            }

            return services;
        }
       public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IPersonService, PersonService>();
            return services;

        }

        private static void MigrateDatabase(string connection)
        {
            try
            {
                var evolveConnecttion = new MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnecttion, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations","db/dataset"},
                    IsEraseDisabled = true 
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {

                Log.Error("Database migration failed", ex);
            }
        }
    }
}
