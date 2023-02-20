namespace DigitalOcean.API.Models.Requests {
    public class ImageAction {
        /// <summary>
        /// Type of action
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The region slug that represents the region target.
        /// </summary>
        /// <remarks>
        /// Used by:
        ///     Transfer Image action
        /// </remarks>
        [JsonPropertyName("region")]
        public string Region { get; set; }
    }
}
