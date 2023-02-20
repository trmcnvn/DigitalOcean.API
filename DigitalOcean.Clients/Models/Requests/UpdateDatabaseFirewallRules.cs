using System.Collections.Generic;

namespace DigitalOcean.API.Models.Requests {
    public class UpdateDatabaseFirewallRules {
        /// <summary>
        /// Firewall rules to update.
        /// </summary>
        [JsonPropertyName("rules")]
        public List<DatabaseFirewallRule> Rules { get; set; }
    }
}
