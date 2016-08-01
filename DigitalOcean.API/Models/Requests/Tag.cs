using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class Tag {
        /// <summary>
        /// The name to change the tag to
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
