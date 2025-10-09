using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoLib;

public class MongoDBConnector
{
    private readonly MongoClient _client;

    public MongoDBConnector(string connectionString)
    {
        _client = new MongoClient(connectionString);
    }

    public bool Ping()
    {
        try
        {
            var db = _client.GetDatabase("admin");
            var cmd = new BsonDocument("ping", 1);
            db.RunCommand<BsonDocument>(cmd);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
