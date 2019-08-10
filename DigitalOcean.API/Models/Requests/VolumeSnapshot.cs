using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class VolumeSnapshot {
        /// <summary>
        /// A human-readable name for the volume snapshot.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A flat array of tag names as strings to apply to the volume snapshot after it is created. Tag names can either be existing or new tags.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
