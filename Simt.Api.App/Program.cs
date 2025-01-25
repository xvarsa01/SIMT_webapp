using Simt.Api.BL.Installers;
using Simt.Api.DAL.Installers;
using Simt.Api.DAL.Migrator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = null; // Or set a valid HTTPS port
});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureDependencies(builder.Services);

ConfigureOpenApiDocuments(builder.Services);
ConfigureSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

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

void ConfigureOpenApiDocuments(IServiceCollection serviceCollection)
{
    serviceCollection.AddEndpointsApiExplorer();
    serviceCollection.AddOpenApiDocument();
}

void ConfigureSwaggerGen()
{
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "SIMT API",
            Version = "v1",
            Description = "API Documentation"
        });

        options.AddServer(new Microsoft.OpenApi.Models.OpenApiServer
        {
            //This is for gen docs and direct connect to api
            Url = "https://localhost:7259"
        });
        options.CustomOperationIds(apiDesc =>
        {
            var controllerName = apiDesc.ActionDescriptor.RouteValues["controller"];
            var actionName = apiDesc.ActionDescriptor.RouteValues["action"];
            return $"{controllerName}_{actionName}";
        });
    });
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