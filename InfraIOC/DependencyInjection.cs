using Application.Service.Interface;
using Application.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Data.Repositories;
using Domain.Repositories;
using Application.Mapping;
using Microsoft.AspNetCore.Hosting;
using Domain.Repositories.Generic;
using Data.Repositories.Generic;
using Application.Hypermedia.Filters;
using Application.Hypermedia.Enricher;
using Domain.SecurityConfig;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            var filterOptions = new HyperMediaFileOptions();
            filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
            services.AddSingleton(filterOptions);
            var tokenConfigurations = new TokenConfiguration();

              new ConfigureFromConfigurationOptions<TokenConfiguration>(
              configuration.GetSection("TokenConfigurations")
              ).Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILoginService, LoginService>();
            return services;

        }



    }
}
