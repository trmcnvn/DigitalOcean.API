using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class DatabaseReplica {
        /// <summary>
        /// The name to give the read-only replica.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A slug identifier for the region where the read-only replica will be located. If excluded, the replica will be placed in the same region as the cluster.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// A slug identifier representing the size of the node for the read-only replica. The size of the replica must be at least as large as the node size for the database cluster from which it is replicating.
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// A flat array of tag names as strings to apply to the read-only replica after it is created. Tag names can either be existing or new tags.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
