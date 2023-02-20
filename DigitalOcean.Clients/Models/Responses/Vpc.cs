namespace DigitalOcean.Clients.Models.Responses;

public class Vpc {
    /// <summary>
    /// A unique ID that can be used to identify and reference the VPC.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The uniform resource name (URN) for the VPC.
    /// </summary>
    public string Urn { get; set; }

    /// <summary>
    /// The name of the VPC.
    /// Must be unique and may only contain alphanumeric characters, dashes, and periods.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The name of the VPC.
    /// Must be unique and may only contain alphanumeric characters, dashes, and periods.
    /// </summary>
    public string Region { get; set; }

    /// <summary>
    /// The range of IP addresses in the VPC in CIDR notation.
    /// </summary>
    [JsonPropertyName("ip_range")]
    public string IpRange { get; set; }

    /// <summary>
    /// A free-form text field for describing the VPC's purpose.
    /// It may be a maximum of 255 characters.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// A boolean value indicating whether or not the VPC is the default one for the region.
    /// </summary>
    public bool Default { get; set; }

    /// <summary>
    /// A time value given in ISO8601 combined date and time format.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
}
