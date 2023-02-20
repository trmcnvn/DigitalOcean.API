using System;
using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses; 

public class DatabaseReplica {
    /// <summary>
    /// A unique, human-readable name referring to a read-only replica.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// An object containing the information required to connect to the read-only replica.
    /// </summary>
    public DatabaseConnection Connection { get; set; }

    /// <summary>
    /// An object containing the information required to connect to the read-only replica via the private network.
    /// </summary>
    public DatabaseConnection PrivateConnection { get; set; }

    /// <summary>
    /// The slug identifier for the region where the read-only replica is located.
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// A string representing the current status of the read-only replica. Possible values include forking and active.
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// A time value given in ISO8601 combined date and time format that represents when the read-only replica was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// An array of tags that have been applied to the database cluster.
    /// </summary>
    public List<string> Tags { get; set; }
}