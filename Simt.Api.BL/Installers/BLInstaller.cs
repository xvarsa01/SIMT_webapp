using Microsoft.Extensions.DependencyInjection;
using Simt.Api.BL.Facades.Interface;
using Simt.Api.BL.Mappers.InterfaceBase;

namespace Simt.Api.BL.Installers;

public static class BLInstaller
{
    public static void AddBLServices(this IServiceCollection services)
    {
        services.Scan(selector => selector
            .FromAssemblyOf<BusinessLogic>()
            .AddClasses(filter => filter.AssignableTo(typeof(IFacade<,,,>)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());
        
        services.Scan(selector => selector
            .FromAssemblyOf<BusinessLogic>()
            .AddClasses(filter => filter.AssignableTo(typeof(IModelMapper<,,,>)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());
    }
}
