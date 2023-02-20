namespace DigitalOcean.API.Models.Requests {
    public class ConnectionPool {
        /// <summary>
        /// A unique name for the connection pool.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The PGBouncer transaction mode for the connection pool. The allowed values are session, transaction, and statement.
        /// </summary>
        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        /// <summary>
        /// The desired size of the PGBouncer connection pool. The maximum allowed size is determined by the size of the cluster's primary node. 25 backend server connections are allowed for every 1GB of RAM. Three are reserved for maintenance. For example, a primary node with 1 GB of RAM allows for a maximum of 22 backend server connections while one with 4 GB would allow for 97. Note that these are shared across all connection pools in a cluster.
        /// </summary>
        [JsonPropertyName("size")]
        public int Size { get; set; }

        /// <summary>
        /// The database for use with the connection pool.
        /// </summary>
        [JsonPropertyName("db")]
        public string Db { get; set; }

        /// <summary>
        /// The name of the user for use with the connection pool.
        /// </summary>
        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}
