using FluentAssertions.Common;
using Microservicio.Data;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Agregar configuración desde appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

// ...

builder.Services.AddScoped<DbConnector>(provider => new DbConnector(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
