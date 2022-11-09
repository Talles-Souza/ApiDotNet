using Data.Context;
using Data.Repositories;
using Domain.Repositories;
using Domain.SecurityConfig;
using IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Configuration;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastruture(builder.Configuration, builder.Environment);
builder.Services.AddTransient<ITokenRepository, TokenRepository>();
builder.Services.AddServices(builder.Configuration);
builder.Services.AddDbContext<MySqlContext>(options =>
           options.UseMySql
           ("server=localhost; database=dotnet;Uid=root;pwd=dias0502",
           Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")));


builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();  

}));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api test dotnet 6",
        Version = "v1",
        Description = "Api in dotnet 6, created for study and testing purposes",
        Contact= new OpenApiContact
        {
            Name="Talles Dias",
            Url=new Uri("https://github.com/Talles-Souza/ApiDotNet")
        }
    }) ;
});
//builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.

//if (app.Environment.IsDevelopment())
//{
    
//}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.MapControllerRoute("DefaultApi", "{controller=values}/{id}");


app.Run();
