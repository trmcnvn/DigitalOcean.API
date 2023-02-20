namespace DigitalOcean.Clients.Models.Requests; 

public class UpdateDatabaseFirewallRules {
    /// <summary>
    /// Firewall rules to update.
    /// </summary>
    [JsonPropertyName("rules")]
    public List<DatabaseFirewallRule> Rules { get; set; }
}