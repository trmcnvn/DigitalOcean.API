using System.Collections.Generic;

namespace DigitalOcean.API.Models.Requests {
    public class Firewall {
        /// <summary>
        /// A human-readable name for a Firewall.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// An object specifying the inbound access rules for a Firewall.
        /// </summary>
        [JsonPropertyName("inbound_rules")]
        public List<InboundRule> InboundRules { get; set; }

        /// <summary>
        /// An object specifying the outbound access rules for a Firewall.
        /// </summary>
        [JsonPropertyName("outbound_rules")]
        public List<OutboundRule> OutboundRules { get; set; }

        /// <summary>
        /// An array containing the IDs of the Droplets to be assigned to the Firewall.
        /// </summary>
        [JsonPropertyName("droplet_ids")]
        public List<long> DropletIds { get; set; }

        /// <summary>
        /// An array containing the names of the Tags to be assigned to the Firewall.
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
