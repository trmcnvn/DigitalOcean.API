namespace DigitalOcean.API.Models.Requests {
    public class ResizeDatabase {
        /// <summary>
        /// A slug identifier representing desired size of the nodes in the cluster.
        /// </summary>
        [JsonPropertyName("size")]
        public string Size { get; set; }

        /// <summary>
        /// The number of nodes in the database cluster. Valid values are 1-3. In addition to the primary node, up to two standby nodes may be added for highly available configurations.
        /// </summary>
        [JsonPropertyName("num_nodes")]
        public int NumNodes { get; set; }
    }
}
