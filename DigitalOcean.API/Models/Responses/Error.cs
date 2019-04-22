using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Responses {
    public class Error {
        /// <summary>
        /// The error identifier
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Detailed error message
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
