using MongoLib;

Console.WriteLine("=== Database Ping REPL ===");
Console.WriteLine("Type 'exit' at any time to quit.");
Console.WriteLine();

while (true)
{
    Console.Write("Choose database (mongo / postgres): ");
    var dbChoice = Console.ReadLine()?.Trim().ToLower();

    if (string.IsNullOrWhiteSpace(dbChoice))
    {
        Console.WriteLine("Please enter a value.");
        Console.WriteLine();
        continue;
    }

    if (dbChoice == "exit")
    {
        Console.WriteLine("Goodbye!");
        break;
    }

    IDbConnector? connector = dbChoice switch
    {
        "mongo" or "mongodb" => CreateMongoConnector(),
        "postgres" or "postgresql" or "pg" => CreatePostgresConnector(),
        _ => null
    };

    if (connector is null)
    {
        Console.WriteLine("❌ Unsupported database type. Please choose 'mongo' or 'postgres'.");
        Console.WriteLine();
        continue;
    }

    Console.WriteLine("Pinging database...");
    bool success = connector.Ping();

    Console.WriteLine(success
        ? "✅ Connection successful!"
        : "❌ Connection failed. Check your connection string and that the DB is running.");
    Console.WriteLine();
}

// local helpers so we don’t repeat logic above
static IDbConnector? CreateMongoConnector()
{
    Console.Write("Enter MongoDB connection string (or type 'back' to re-choose DB): ");
    var connStr = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(connStr) || connStr.Trim().ToLower() == "back")
    {
        return null;
    }

    return new MongoDBConnector(connStr);
}

static IDbConnector? CreatePostgresConnector()
{
    Console.Write("Enter PostgreSQL connection string (or type 'back' to re-choose DB): ");
    var connStr = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(connStr) || connStr.Trim().ToLower() == "back")
    {
        return null;
    }

    return new PostgresConnector(connStr);
}
