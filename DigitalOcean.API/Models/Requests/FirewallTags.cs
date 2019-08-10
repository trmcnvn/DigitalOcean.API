using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class FirewallTags {
        /// <summary>
        /// An array containing the names of the Tags to be assigned to the Firewall.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
