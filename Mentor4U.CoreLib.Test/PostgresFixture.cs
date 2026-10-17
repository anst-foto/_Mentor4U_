using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Testcontainers.PostgreSql;

using Xunit;

namespace Mentor4U.CoreLib.Test;

public sealed class PostgresFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _container = new PostgreSqlBuilder("postgres:18")
        .WithDatabase("mentor4u_tests")
        .WithUsername("test")
        .WithPassword("test")
        .Build();

    public string ConnectionString => _container.GetConnectionString();

    public async Task InitializeAsync()
    {
        await _container.StartAsync();

        // Создаём схему на основе текущей модели EF Core.
        // В реальном проекте здесь лучше вызывать context.Database.MigrateAsync().
        await using var context = CreateContext();
        await context.Database.EnsureCreatedAsync();
        
        await context.Database.ExecuteSqlRawAsync(
                """
                CREATE UNIQUE INDEX IF NOT EXISTS "IX_Users_AccountId"
                ON "Users" ("AccountId");
                """);
    }

    public async Task DisposeAsync()
    {
        await _container.DisposeAsync();
    }

    public DataBaseContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<DataBaseContext>()
            .UseNpgsql(ConnectionString)
            .Options;

        return new DataBaseContext(options);
    }
}