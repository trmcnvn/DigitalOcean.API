using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class TagResource {
        /// <summary>
        /// The id of the resource to be tagged
        /// </summary>
        [JsonProperty("resource_id")]
        public string Id;

        /// <summary>
        /// The type of the resource to be tagged
        /// </summary>
        [JsonProperty("resource_type")]
        public string Type;
    }
}
