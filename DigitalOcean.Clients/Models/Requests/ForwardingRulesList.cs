using System.Collections.Generic;

namespace DigitalOcean.API.Models.Requests {
    public class ForwardingRulesList {
        [JsonPropertyName("forwarding_rules")]
        public List<ForwardingRule> ForwardingRules { get; set; }
    }
}
