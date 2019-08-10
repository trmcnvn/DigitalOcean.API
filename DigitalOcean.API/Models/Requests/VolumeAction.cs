using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class VolumeAction {
        /// <summary>
        /// Type of action
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The unique identifier for the Droplet the volume will be attached or detached from.
        /// </summary>
        [JsonProperty("droplet_id")]
        public int? DropletId { get; set; }

        /// <summary>
        /// The slug identifier for the region the volume is located in.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// The name of the Block Storage volume.
        /// </summary>
        [JsonProperty("volume_name")]
        public string VolumeName { get; set; }

        /// <summary>
        /// The new size of the Block Storage volume in GiB (1024^3).
        /// </summary>
        [JsonProperty("size_gigabytes")]
        public int? SizeGigabytes { get; set; }
    }
}
