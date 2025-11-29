using Npgsql;

namespace MongoLib;

public class PostgresConnector : IDbConnector
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
            using var conn = new NpgsqlConnection(_connectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT 1;", conn);
            var result = cmd.ExecuteScalar();

            return result is int or long or decimal or double;
        }
        catch
        {
            return false;
        }
    }
}
