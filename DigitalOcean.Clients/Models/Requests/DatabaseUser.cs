namespace DigitalOcean.API.Models.Requests {
    public class DatabaseUser {
        /// <summary>
        /// The name to give the database user.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// An object containing additional configuration details for MySQL clusters.
        /// </summary>
        [JsonPropertyName("mysql_settings")]
        public MySqlSettings MySqlSettings { get; set; }
    }
}
