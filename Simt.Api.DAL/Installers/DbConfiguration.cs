namespace Simt.Api.DAL.Installers;

public record DbConfiguration
{
    public SqlServerConfig SqlServer { get; init; } = new();
    public SqliteConfig Sqlite { get; init; } = new();
}

public record SqlServerConfig
{
    public string ConnectionString { get; set; } = null!;
    public bool SeedDemoData { get; init; }
    public bool RecreateDatabaseEachTime { get; init; }
    public bool Enabled { get; set; }
}

public record SqliteConfig
{
    public string DatabaseName { get; set; } = null!;
    public bool SeedDemoData { get; set; }
    public bool RecreateDatabaseEachTime { get; set; }
    public bool Enabled { get; set; }
}