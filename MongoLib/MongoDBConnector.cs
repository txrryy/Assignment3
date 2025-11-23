using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoLib;

public class MongoDBConnector : IDbConnector
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
            // You can change "admin" to another DB if you want
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
