using MongoDB.Driver;

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
    // to be implemented after writing tests (step 9)
    return false;
}

}