using Microsoft.EntityFrameworkCore;
using Simt.Api.BL.Facades;
using Simt.Api.BL.Mappers;
using Simt.Api.BL.Mappers.InterfaceBase;
using Simt.Api.DAL;
using Simt.Api.DAL.entities;
using Simt.Api.DAL.Repositories;
using Simt.Common.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                           ?? throw new ArgumentException("The connection string is missing");
    serviceCollection.AddDbContext<SimtDbContext>(options =>
        options.UseSqlite(connectionString));

    serviceCollection.AddScoped<VehicleFacade>();
    serviceCollection.AddScoped<PlayerFacade>();
    serviceCollection.AddScoped<LineFacade>();
    serviceCollection.AddScoped<ServiceFacade>();

    serviceCollection.AddScoped<VehicleRepository>();
    serviceCollection.AddScoped<PlayerRepository>();
    serviceCollection.AddScoped<LineRepository>();
    serviceCollection.AddScoped<ServiceRepository>();

    serviceCollection.AddScoped<ModelMapperBase<VehicleEntity, VehicleListModel, VehicleDetailModel>, VehicleModelMapper>();
    serviceCollection.AddScoped<ModelMapperBase<PlayerEntity, PlayerListModel, PlayerProfileModel>, PlayerModelMapper>();
    serviceCollection.AddScoped<ModelMapperBase<LineEntity, LineListModel, LineDetailModel>, LineModelMapper>();
    serviceCollection.AddScoped<ModelMapperBase<ServiceEntity, ServiceListModel, ServiceDetailModel>, ServiceModelMapper>();
}