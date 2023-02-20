namespace DigitalOcean.Clients.Models.Responses; 

public class DatabaseConnection {
    /// <summary>
    /// A connection string in the format accepted by the psql command. This is provided as a convenience and should be able to be constructed by the other attributes.
    /// </summary>
    public string Uri { get; set; }

    /// <summary>
    /// The name of the default database.
    /// </summary>
    public string Database { get; set; }

    /// <summary>
    /// The FQDN pointing to the database cluster's current primary node.
    /// </summary>
    public string Host { get; set; }

    /// <summary>
    /// The port on which the database cluster is listening.
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// The default user for the database.
    /// </summary>
    public string User { get; set; }

    /// <summary>
    /// The randomly generated password for the default user.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// A boolean value indicating if the connection should be made over SSL.
    /// </summary>
    public bool Ssl { get; set; }
}