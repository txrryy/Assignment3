using System.Threading.Tasks;
using Xunit;
using Testcontainers.MongoDb;

namespace MongoLib.Tests;

public class MongoDBConnectorTests : IAsyncLifetime
{
    private readonly MongoDbContainer _mongo;

    public MongoDBConnectorTests()
    {
        _mongo = new MongoDbBuilder().Build();
    }

    public async Task InitializeAsync() => await _mongo.StartAsync();
    public async Task DisposeAsync()    => await _mongo.DisposeAsync();

    [Fact]
    public void Ping_ShouldReturnTrue_WhenContainerIsRunning()
    {
        var connector = new MongoDBConnector(_mongo.GetConnectionString());
        Assert.True(connector.Ping());
    }
}
