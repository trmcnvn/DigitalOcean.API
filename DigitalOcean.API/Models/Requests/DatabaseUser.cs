using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class DatabaseUser {
        /// <summary>
        /// The name to give the database user.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
