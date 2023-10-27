using SmartGenealogy.Infrastructure.Constants.Database;

namespace SmartGenealogy.Infrastructure.Extensions;

internal static class DbContextOptionsBuilderExtensions
{
    internal static DbContextOptionsBuilder UseDatabase(this DbContextOptionsBuilder builder, string dbProvider,
        string connectionString)
    {
        switch (dbProvider.ToLowerInvariant())
        {
            case DbProviderKeys.Npgsql:
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                return builder.UseNpgsql(connectionString,
                    e => e.MigrationsAssembly("SmartGenealogy.Migrators.PostgreSQL"))
                    .UseSnakeCaseNamingConvention();

            case DbProviderKeys.SqlServer:
                return builder.UseSqlServer(connectionString,
                    e => e.MigrationsAssembly("SmartGenealogy.Migrators.MSSQL"));

            case DbProviderKeys.SqLite:
                return builder.UseSqlite(connectionString,
                    e => e.MigrationsAssembly("SmartGenealogy.Migrators.SqLite"));

            default:
                throw new InvalidOperationException($"DB Provider {dbProvider} is not supported.");
        }
    }
}