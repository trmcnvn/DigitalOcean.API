using System.Collections.Generic;

namespace DigitalOcean.API.Models.Requests {
    public class FirewallRules {
        /// <summary>
        /// An array containing the inbound rules to be assigned to the Firewall.
        /// </summary>
        [JsonPropertyName("inbound_rules")]
        public List<InboundRule> InboundRules { get; set; }

        /// <summary>
        /// An array containing the outbound rules  to be assigned to the Firewall.
        /// </summary>
        [JsonPropertyName("outbound_rules")]
        public List<OutboundRule> OutboundRules { get; set; }
    }
}
