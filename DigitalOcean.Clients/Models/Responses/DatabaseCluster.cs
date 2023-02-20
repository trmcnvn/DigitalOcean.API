namespace DigitalOcean.Clients.Models.Responses; 

public class DatabaseCluster {
    /// <summary>
    /// A unique ID that can be used to identify and reference a database cluster.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// A unique, human-readable name referring to a database cluster.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A slug representing the database engine used for the cluster.
    /// </summary>
    public string Engine { get; set; }

    /// <summary>
    /// A string representing the version of the database engine in use for the cluster.
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    /// An object containing the information required to connect to the database.
    /// </summary>
    public DatabaseConnection Connection { get; set; }

    /// <summary>
    /// An object containing the information required to connect to the database via the private network.
    /// </summary>
    public DatabaseConnection PrivateConnection { get; set; }

    /// <summary>
    /// An array containing objects describing the database's users.
    /// </summary>
    public List<DatabaseUser> Users { get; set; }

    /// <summary>
    /// An array of strings containing the names of databases created in the database cluster.
    /// </summary>
    public List<string> DbNames { get; set; }

    /// <summary>
    /// The number of nodes in the database cluster.
    /// </summary>
    public int NumNodes { get; set; }

    /// <summary>
    /// The slug identifier representing the size of the nodes in the database cluster.
    /// </summary>
    public string Size { get; set; }

    /// <summary>
    /// The slug identifier for the region where the database cluster is located.
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// A string representing the current status of the database cluster. Possible values include creating, online, resizing, and migrating.
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// An object containing information about any pending maintenance for the database cluster and when it will occur (see below).
    /// </summary>
    public MaintenanceWindow MaintenanceWindow { get; set; }

    /// <summary>
    /// A time value given in ISO8601 combined date and time format that represents when the database cluster was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// An array of tags that have been applied to the database cluster.
    /// </summary>
    public List<string> Tags { get; set; }

    /// <summary>
    /// A string specifying the UUID of the VPC to which the database cluster is assigned.
    /// </summary>
    public string PrivateNetworkUuid { get; set; }
}