namespace MongoLib;

public interface IDbConnector
{
    /// <summary>
    /// Tries to connect / ping the database.
    /// Returns true if successful, false otherwise.
    /// </summary>
    bool Ping();
}
