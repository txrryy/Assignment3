using System.Threading.Tasks;
using Xunit;
using MongoLib;
using Testcontainers.PostgreSql;

namespace MongoLib.Tests;

public class PostgresConnectorTests : IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgres;

    public PostgresConnectorTests()
    {
        _postgres = new PostgreSqlBuilder().Build();
    }

    public async Task InitializeAsync() => await _postgres.StartAsync();
    public async Task DisposeAsync()    => await _postgres.DisposeAsync();

    [Fact]
    public void Ping_ShouldReturnTrue_WhenConnected()
    {
        var connector = new PostgresConnector(_postgres.GetConnectionString());
        Assert.True(connector.Ping());
    }

    [Fact]
    public void Ping_ShouldReturnFalse_WhenInvalidConnection()
    {
        var bad = "Host=invalid;Username=none;Password=bad;Database=fake;";
        var connector = new PostgresConnector(bad);
        Assert.False(connector.Ping());
    }
}
