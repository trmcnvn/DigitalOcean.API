using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class Database {
        /// <summary>
        /// The name to give the database
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
