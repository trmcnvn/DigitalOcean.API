using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class KubernetesNodePool {
        /// <summary>
        /// The slug identifier for the type of Droplet to be used as workers in the node pool.
        /// </summary>
        [JsonProperty("size")]
        public string Size { get; set; }

        /// <summary>
        /// A human-readable name for the node pool.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The number of Droplet instances in the node pool.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

        /// <summary>
        /// A flat array of tag names as strings to be applied to the node pool. All node pools will be automatically tagged "k8s," "k8s-worker," and "k8s:$K8S_CLUSTER_ID" in addition to any tags provided by the user.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}
