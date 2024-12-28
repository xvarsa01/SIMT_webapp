using Microsoft.EntityFrameworkCore;
using Simt.BL.Facades;
using Simt.DAL;
using Simt.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
//                        ?? throw new ArgumentException("The connection string is missing");
// builder.Services.AddScoped<VehicleFacade>();
// builder.Services.AddScoped<VehicleRepository>();
// builder.Services.AddDbContext<SimtDbContext>(options =>
//     options.UseSqlite(connectionString));


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