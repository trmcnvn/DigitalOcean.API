using System;

namespace DigitalOcean.API.Models.Responses;

public class DatabaseFirewallRule {
    /// <summary>
    /// A unique ID for the firewall rule itself.
    /// </summary>
    [JsonPropertyName("uuid")]
    public string Uuid { get; set; }

    /// <summary>
    /// A unique ID for the database cluster to which the rule is applied.
    /// </summary>
    [JsonPropertyName("cluster_uuid")]
    public string ClusterUuid { get; set; }

    /// <summary>
    /// The type of resource that the firewall rule allows to access the database cluster.
    /// The possible values are: 'droplet', 'k8s', 'ip_addr', or 'tag'
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// The ID of the specific resource, the name of a tag applied to a group of resources, or the IP address that the firewall rule allows to access the database cluster.
    /// </summary>
    [JsonPropertyName("value")]
    public string Value { get; set; }

    /// <summary>
    /// A time value given in ISO8601 combined date and time format that represents when the firewall rule was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
}
