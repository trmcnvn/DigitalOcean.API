namespace DigitalOcean.API.Models.Responses; 

public class ConnectionPool {
    /// <summary>
    /// The name for the connection pool.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The PGBouncer pool mode for the connection pool. The allowed values are session, transaction, and statement.
    /// </summary>
    public string Mode { get; set; }

    /// <summary>
    /// The size of the PGBouncer connection pool.
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// The database for use with the connection pool.
    /// </summary>
    public string Db { get; set; }

    /// <summary>
    /// The name of the user for use with the connection pool.
    /// </summary>
    public string User { get; set; }

    /// <summary>
    /// An object containing the information required to access the database using the connection pool.
    /// </summary>
    public DatabaseConnection Connection { get; set; }

    /// <summary>
    /// An object containing the information required to connect to the database using the connection pool via the private network.
    /// </summary>
    public DatabaseConnection PrivateConnection { get; set; }
}