using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class FirewallRules {
        /// <summary>
        /// An array containing the inbound rules to be assigned to the Firewall.
        /// </summary>
        [JsonProperty("inbound_rules")]
        public List<InboundRule> InboundRules { get; set; }

        /// <summary>
        /// An array containing the outbound rules  to be assigned to the Firewall.
        /// </summary>
        [JsonProperty("outbound_rules")]
        public List<OutboundRule> OutboundRules { get; set; }
    }
}
