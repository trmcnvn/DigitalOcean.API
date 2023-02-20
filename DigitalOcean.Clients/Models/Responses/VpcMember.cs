namespace DigitalOcean.Clients.Models.Responses;

public class VpcMember {
    /// <summary>
    /// The name of the resource.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The uniform resource name (URN) for the resource in the format do:resource_type:resource_id.
    /// </summary>
    [JsonPropertyName("urn")]
    public string Urn { get; set; }

    /// <summary>
    /// A time value given in ISO8601 combined date and time format that represents when the resource was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
}
