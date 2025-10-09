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
public void Ping_ShouldReturnFalse_WhenConnectionStringIsInvalid()
{
    var connector = new MongoDBConnector("mongodb://invalid-host:27017");
    Assert.False(connector.Ping());
}

}
