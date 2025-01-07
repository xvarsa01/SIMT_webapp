using Simt.Api.BL.Installers;
using Simt.Api.DAL.Installers;
using Simt.Api.DAL.Migrator;

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

MigrateDb(app.Services.GetRequiredService<IDbMigrator>());

app.Run();

void ConfigureDependencies(IServiceCollection serviceCollection)
{
    var dbConfig = GetDbConfig();

    serviceCollection.AddSingleton<IDALInstaller, DALInstaller>();
    var configurator = serviceCollection.BuildServiceProvider().GetRequiredService<IDALInstaller>();
    configurator.AddDALServices(serviceCollection, dbConfig);
    
    serviceCollection.AddBLServices();
    
    serviceCollection.AddSingleton<IDbMigrator, DbMigrator>();
}

DbConfiguration GetDbConfig()
{
    DbConfiguration dbConfig = new();
    builder.Configuration.GetSection("DAL").Bind(dbConfig);
    return dbConfig;
}

void MigrateDb(IDbMigrator migrator) => migrator.Migrate();
public partial class Program
{
}