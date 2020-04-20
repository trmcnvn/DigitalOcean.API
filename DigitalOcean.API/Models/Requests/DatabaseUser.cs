using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class DatabaseUser {
        /// <summary>
        /// The name to give the database user.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// An object containing additional configuration details for MySQL clusters.
        /// </summary>
        [JsonProperty("mysql_settings")]
        public MySqlSettings MySqlSettings { get; set; }
    }
}
