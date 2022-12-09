using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class AppDatabaseSpec {
        /// <summary>
        /// The name of the underlying DigitalOcean DBaaS cluster. This is required for production databases. For dev databases, if cluster_name is not set, a new cluster will be provisioned.
        /// </summary>
        [JsonProperty("cluster_name")]
        public string ClusterName { get; set; }

        /// <summary>
        /// The name of the MySQL or PostgreSQL database to configure.
        /// </summary>
        [JsonProperty("db_name")]
        public string DbName { get; set; }

        /// <summary>
        /// The name of the MySQL or PostgreSQL user to configure.
        /// </summary>
        [JsonProperty("db_user")]
        public string DbUser { get; set; }

        /// <summary>
        /// Enum: "UNSET" "MYSQL" "PG" "REDIS"
        ///MYSQL: MySQL
        /// PG: PostgreSQL
        ///REDIS: Redis
        /// </summary>
        [JsonProperty("engine")]
        public string DatabaseEngine { get; set; }

        /// <summary>
        /// [ 2 .. 32 ] characters ^[a-z][a-z0-9-]{0,30}[a-z0-9]$
        /// The name. Must be unique across all components within the same app.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Whether this is a production or dev database.
        /// </summary>
        [JsonProperty("production")]
        public bool Production { get; set; }

        /// <summary>
        /// The version of the database engine
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
