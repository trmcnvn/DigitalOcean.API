namespace DigitalOcean.Clients.Models.Requests; 

public class FirewallTags {
    /// <summary>
    /// An array containing the names of the Tags to be assigned to the Firewall.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }
}