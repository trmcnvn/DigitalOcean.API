namespace DigitalOcean.Clients.Models.Requests; 

public class FirewallDroplets {
    /// <summary>
    /// An array containing the IDs of the Droplets to be assigned to the Firewall.
    /// </summary>
    [JsonPropertyName("droplet_ids")]
    public List<long> DropletIds { get; set; }
}