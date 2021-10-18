using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class Routes {
        /// <summary>
        /// An HTTP path prefix. Paths must start with / and must be unique across all components within an app.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
