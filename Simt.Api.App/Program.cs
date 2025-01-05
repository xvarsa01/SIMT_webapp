using Microsoft.EntityFrameworkCore;
using Simt.Api.BL;
using Simt.Api.BL.Facades;
using Simt.Api.BL.Installers;
using Simt.Api.BL.Mappers;
using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Installers;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = null; // Or set a valid HTTPS port
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureDependencies(builder.Services);


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

void ConfigureDependencies(IServiceCollection serviceCollection)
{
    var dbName = builder.Configuration.GetConnectionString("DefaultConnection")
                           ?? throw new ArgumentException("The connection string is missing");
    
    var connectionString = "Data Source=../Simt.Api.DAL/";
    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "true")
    {
        connectionString = "Data Source=../../../../Simt.Api.DAL/";
    }
    
    serviceCollection.AddDbContext<SimtDbContext>(options =>
        options.UseSqlite(connectionString+dbName));

    serviceCollection.AddBLServices();
    serviceCollection.AddDALServices();
}

public partial class Program
{
}