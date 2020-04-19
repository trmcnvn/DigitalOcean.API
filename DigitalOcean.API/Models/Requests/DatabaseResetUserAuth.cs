using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class DatabaseResetUserAuth {
        /// <summary>
        /// An object containing additional configuration details for MySQL cluster users.
        /// </summary>
        [JsonProperty("mysql_settings")]
        public MySqlSettings MySqlSettings { get; set; }
    }
}
