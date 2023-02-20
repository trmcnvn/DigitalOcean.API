using System;

namespace DigitalOcean.API.Models.Requests {
    public class DatabaseBackupRestore {
        /// <summary>
        /// The name of an existing database cluster from which the backup will be restored.
        /// </summary>
        [JsonPropertyName("database_name")]
        public string DatabaseName { get; set; }

        /// <summary>
        /// The timestamp of an existing database cluster backup in ISO8601 combined date and time format.
        /// </summary>
        [JsonPropertyName("backup_created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
