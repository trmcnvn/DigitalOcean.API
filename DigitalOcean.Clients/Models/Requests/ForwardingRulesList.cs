namespace DigitalOcean.Clients.Models.Requests; 

public class ForwardingRulesList {
    [JsonPropertyName("forwarding_rules")]
    public List<ForwardingRule> ForwardingRules { get; set; }
}