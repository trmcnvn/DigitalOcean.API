using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class DatabaseBackup {
        /// <summary>
        /// A unique, human-readable name for the database cluster.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A slug representing the database engine to be used for the cluster. The slug for PostgreSQL, the only engine current supported, is "pg".
        /// </summary>
        [JsonProperty("engine")]
        public string Engine { get; set; }

        /// <summary>
        /// A string representing the version of the database engine to use for the cluster. If excluded, the specified engine's default version is used. The available versions for PostgreSQL, the first supported engine, are "10" and "11" defaulting to the later.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        /// A slug identifier representing the size of the nodes in the database cluster.
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// A slug identifier for the region where the database cluster will be created.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// The number of nodes in the database cluster. Valid values are are 1-3. In addition to the primary node, up to two standby nodes may be added for highly available configurations. The value is inclusive of the primary node. For example, setting the value to 2 will provision a database cluster with a primary node and one standby node.
        /// </summary>
        [JsonProperty("num_nodes")]
        public int NumNodes { get; set; }

        /// <summary>
        /// A flat array of tag names as strings to apply to the database cluster after it is created. Tag names can either be existing or new tags.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// An embedded object containing two attributes specifying the name of the original database cluster and the timestamp of the backup to restore (see below).
        /// </summary>
        [JsonProperty("backup_restore")]
        public DatabaseBackupRestore BackupRestore { get; set; }
    }
}
