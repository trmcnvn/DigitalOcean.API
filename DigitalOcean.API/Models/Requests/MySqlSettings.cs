using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class MySqlSettings {
        /// <summary>
        /// A string specifying the authentication method to be used for connections to the MySQL user account.
        /// The valid values are "mysql_native_password" or "caching_sha2_password".
        /// If excluded when creating a new user, the default for the version of MySQL in use will be used.
        /// As of MySQL 8.0, the default is "caching_sha2_password."
        /// </summary>
        [JsonProperty("auth_plugin")]
        public string AuthPlugin { get; set; }
    }
}
