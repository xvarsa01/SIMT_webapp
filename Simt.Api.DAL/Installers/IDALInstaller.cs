using Microsoft.Extensions.DependencyInjection;

namespace Simt.Api.DAL.Installers;

public interface IDALInstaller
{
    void AddDALServices(IServiceCollection services, DbConfiguration dbConfig);
}