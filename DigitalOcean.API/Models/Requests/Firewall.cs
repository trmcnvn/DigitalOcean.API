using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class Firewall {
        /// <summary>
        /// A human-readable name for a Firewall.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// An object specifying the inbound access rules for a Firewall.
        /// </summary>
        [JsonProperty("inbound_rules")]
        public List<InboundRule> InboundRules { get; set; }

        /// <summary>
        /// An object specifying the outbound access rules for a Firewall.
        /// </summary>
        [JsonProperty("outbound_rules")]
        public List<OutboundRule> OutboundRules { get; set; }

        /// <summary>
        /// An array containing the IDs of the Droplets to be assigned to the Firewall.
        /// </summary>
        [JsonProperty("droplet_ids")]
        public List<long> DropletIds { get; set; }

        /// <summary>
        /// An array containing the names of the Tags to be assigned to the Firewall.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
