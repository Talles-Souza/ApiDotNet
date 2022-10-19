using IoC;
using Microsoft.EntityFrameworkCore.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastruture(builder.Configuration, builder.Environment);
builder.Services.AddServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
