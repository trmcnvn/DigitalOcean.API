namespace DigitalOcean.Clients.Models.Requests; 

public class TagResource {
    /// <summary>
    /// The id of the resource to be tagged
    /// </summary>
    [JsonPropertyName("resource_id")]
    public string Id;

    /// <summary>
    /// The type of the resource to be tagged
    /// </summary>
    [JsonPropertyName("resource_type")]
    public string Type;
}