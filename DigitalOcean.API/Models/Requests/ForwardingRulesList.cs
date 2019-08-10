using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class ForwardingRulesList {
        [JsonProperty("forwarding_rules")]
        public List<ForwardingRule> ForwardingRules { get; set; }
    }
}
