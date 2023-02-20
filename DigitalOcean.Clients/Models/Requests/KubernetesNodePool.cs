using System.Collections.Generic;

namespace DigitalOcean.API.Models.Requests {
    public class KubernetesNodePool {
        /// <summary>
        /// The slug identifier for the type of Droplet to be used as workers in the node pool.
        /// </summary>
        [JsonPropertyName("size")]
        public string Size { get; set; }

        /// <summary>
        /// A human-readable name for the node pool.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The number of Droplet instances in the node pool.
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }

        /// <summary>
        /// An object containing a set of Kubernetes labels.
        /// The keys are user-defined.
        /// </summary>
        [JsonPropertyName("labels")]
        public Dictionary<string, string> Labels { get; set; }

        /// <summary>
        /// A boolean value indicating whether auto-scaling is enabled for this node pool.
        /// This requires DOKS versions at least 1.13.10-do.3, 1.14.6-do.3, or 1.15.3-do.3.
        /// </summary>
        [JsonPropertyName("auto_scale")]
        public bool? AutoScale { get; set; }

        /// <summary>
        /// The minimum number of nodes that this node pool can be auto-scaled to.
        /// This will fail validation if the additional nodes will exceed your account droplet limit.
        /// </summary>
        [JsonPropertyName("min_nodes")]
        public string MinNodes { get; set; }

        /// <summary>
        /// The maximum number of nodes that this node pool can be auto-scaled to.
        /// This can be 0, but your cluster must contain at least 1 node across all node pools.
        /// </summary>
        [JsonPropertyName("max_nodes")]
        public string MaxNodes { get; set; }
    }
}
