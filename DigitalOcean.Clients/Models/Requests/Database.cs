namespace DigitalOcean.API.Models.Requests {
    public class Database {
        /// <summary>
        /// The name to give the database
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
