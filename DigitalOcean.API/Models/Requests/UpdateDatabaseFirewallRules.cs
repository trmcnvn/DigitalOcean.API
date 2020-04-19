using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class UpdateDatabaseFirewallRules {
        /// <summary>
        /// Firewall rules to update.
        /// </summary>
        [JsonProperty("rules")]
        public List<DatabaseFirewallRule> Rules { get; set; }
    }
}
