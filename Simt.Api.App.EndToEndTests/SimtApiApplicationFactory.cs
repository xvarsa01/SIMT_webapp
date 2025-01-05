using System.Reflection;
using Microsoft.AspNetCore.Mvc.Testing;
 
namespace Simt.Api.App.EndToEndTests;

public class SimtApiApplicationFactory : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "true");

        builder.ConfigureServices(collection =>
        {
            var controllerAssemblyName = typeof(Program).Assembly.FullName;
            collection.AddMvc().AddApplicationPart(Assembly.Load(controllerAssemblyName!));
        });
        return base.CreateHost(builder);
    }
}
