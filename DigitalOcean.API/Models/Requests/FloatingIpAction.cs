using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class FloatingIpAction {
        /// <summary>
        /// Type of action
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The unique identifier for the Droplet the Floating IP will be assigned or unassigned from.
        /// </summary>
        [JsonProperty("droplet_id")]
        public int DropletId { get; set; }
    }
}
