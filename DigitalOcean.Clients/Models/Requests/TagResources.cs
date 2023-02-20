namespace DigitalOcean.Clients.Models.Requests; 

public class TagResources {
    /// <summary>
    /// The list of resources to be tagged
    /// </summary>
    [JsonPropertyName("resources")]
    public List<TagResource> Resources { get; set; }
}