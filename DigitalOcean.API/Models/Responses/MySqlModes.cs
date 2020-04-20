using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Responses {
    public class MySqlModes {
        /// <summary>
        /// A string specifying the configured SQL modes for the MySQL cluster.
        /// </summary>
        [JsonProperty("sql_mode")]
        public string SqlMode { get; set; }
    }
}
