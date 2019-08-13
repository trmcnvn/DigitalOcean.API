using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class ImageAction {
        /// <summary>
        /// Type of action
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The region slug that represents the region target.
        /// </summary>
        /// <remarks>
        /// Used by:
        ///     Transfer Image action
        /// </remarks>
        [JsonProperty("region")]
        public string Region { get; set; }
    }
}
