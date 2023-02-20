namespace DigitalOcean.API.Models.Requests {
    public class Tag {
        /// <summary>
        /// The name to change the tag to
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
