using Npgsql;

namespace MongoLib;

public class PostgresConnector : IDBConnector
{
    private readonly string _connectionString;

    public PostgresConnector(string connectionString)
    {
        _connectionString = connectionString;
    }

    public bool Ping()
    {
        try
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            using var cmd = new NpgsqlCommand("SELECT 1;", connection);
            cmd.ExecuteScalar();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
