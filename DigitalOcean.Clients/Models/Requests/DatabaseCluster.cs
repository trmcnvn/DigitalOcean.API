namespace DigitalOcean.Clients.Models.Requests; 

public class DatabaseCluster {
    /// <summary>
    /// A unique, human-readable name for the database cluster.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// A slug representing the database engine to be used for the cluster. The slug for PostgreSQL, the only engine current supported, is "pg".
    /// </summary>
    [JsonPropertyName("engine")]
    public string Engine { get; set; }

    /// <summary>
    /// A string representing the version of the database engine to use for the cluster. If excluded, the specified engine's default version is used. The available versions for PostgreSQL, the first supported engine, are "10" and "11" defaulting to the later.
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; set; }

    /// <summary>
    /// A slug identifier representing the size of the nodes in the database cluster.
    /// </summary>
    [JsonPropertyName("size")]
    public string Size { get; set; }

    /// <summary>
    /// A slug identifier for the region where the database cluster will be created.
    /// </summary>
    [JsonPropertyName("region")]
    public string Region { get; set; }

    /// <summary>
    /// The number of nodes in the database cluster. Valid values are are 1-3. In addition to the primary node, up to two standby nodes may be added for highly available configurations. The value is inclusive of the primary node. For example, setting the value to 2 will provision a database cluster with a primary node and one standby node.
    /// </summary>
    [JsonPropertyName("num_nodes")]
    public int NumNodes { get; set; }

    /// <summary>
    /// A flat array of tag names as strings to apply to the database cluster after it is created. Tag names can either be existing or new tags.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }

    /// <summary>
    /// A string specifying the UUID of the VPC to which the database cluster will be assigned.
    /// If excluded, the cluster will be assigned to your account's default VPC for the region.
    /// </summary>
    [JsonPropertyName("private_network_uuid")]
    public string PrivateNetworkUuid { get; set; }
}