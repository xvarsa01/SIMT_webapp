using Microsoft.Extensions.DependencyInjection;
using Simt.Api.DAL.Repositories;

namespace Simt.Api.DAL.Installers;

public static class DALInstaller
{
    public static void AddDALServices(this IServiceCollection services)
    {
        services.Scan(selector => selector
            .FromAssemblyOf<SimtDbContext>() 
            .AddClasses(filter => filter.AssignableTo(typeof(IRepository<>))) 
            .AsSelf()
            .WithScopedLifetime());
    }
}
