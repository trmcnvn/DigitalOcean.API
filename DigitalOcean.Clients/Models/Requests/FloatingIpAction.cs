namespace DigitalOcean.Clients.Models.Requests; 

public class FloatingIpAction {
    /// <summary>
    /// Type of action
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// The unique identifier for the Droplet the Floating IP will be assigned or unassigned from.
    /// </summary>
    [JsonPropertyName("droplet_id")]
    public long? DropletId { get; set; }
}