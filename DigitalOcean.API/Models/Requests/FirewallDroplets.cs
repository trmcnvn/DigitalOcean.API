using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class FirewallDroplets {
        /// <summary>
        /// An array containing the IDs of the Droplets to be assigned to the Firewall.
        /// </summary>
        [JsonProperty("droplet_ids")]
        public List<long> DropletIds { get; set; }
    }
}
