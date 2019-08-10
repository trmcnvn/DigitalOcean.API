using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class UpdateImage {
        /// <summary>
        /// The display name to be given to an image.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The name of a custom image's distribution.
        /// </summary>
        [JsonProperty("distribution")]
        public string Distribution { get; set; }

        /// <summary>
        /// An optional free-form text field to describe an image.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
