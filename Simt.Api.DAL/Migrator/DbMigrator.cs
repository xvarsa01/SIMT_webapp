using Microsoft.EntityFrameworkCore;
using Simt.Api.DAL.Installers;

namespace Simt.Api.DAL.Migrator;

public class DbMigrator(IDbContextFactory<SimtDbContext> dbContextFactory, DbConfiguration dbConfiguration)
    : IDbMigrator
{
    public void Migrate() => MigrateAsync(CancellationToken.None).GetAwaiter().GetResult();

    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        await using SimtDbContext dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
        if(dbConfiguration.Sqlite is { Enabled: true, RecreateDatabaseEachTime: true } || 
           dbConfiguration.SqlServer is { Enabled: true, RecreateDatabaseEachTime: true })
        {
            await dbContext.Database.EnsureDeletedAsync(cancellationToken);
        }

        // await dbContext.Database.MigrateAsync(cancellationToken);           // this creates CD using created Migrations
        await dbContext.Database.EnsureCreatedAsync(cancellationToken);     // this creates DB just using actual seeds
    }
}
