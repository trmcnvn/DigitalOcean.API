using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class FloatingIp {
        /// <summary>
        /// The ID of Droplet that the Floating IP will be assigned to.
        /// This attribute and the "region" attribute are mutually exclusive.
        /// </summary>
        [JsonProperty("droplet_id")]
        public long? DropletId { get; set; }

        /// <summary>
        /// The slug identifier for the region the Floating IP will be reserved to.
        /// This attribute and the "droplet_id" attribute are mutually exclusive.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }
    }
}
