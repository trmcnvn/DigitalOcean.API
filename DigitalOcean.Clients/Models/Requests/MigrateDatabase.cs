namespace DigitalOcean.API.Models.Requests {
    public class MigrateDatabase {
        /// <summary>
        /// A slug identifier for the region to which the database cluster will be migrated.
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }
    }
}
