using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses {
    public class KubernetesNodePool {
        /// <summary>
        /// A unique ID that can be used to identify and reference a specific node pool.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A human-readable name for the node pool.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The slug identifier for the type of Droplet used as workers in the node pool.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// The number of Droplet instances in the node pool.
        /// </summary>
        public string Count { get; set; }

        /// <summary>
        /// An array containing the tags applied to the node pool. All node pools are automatically tagged "k8s," "k8s-worker," and "k8s:$K8S_CLUSTER_ID."
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// An object specifying the details of a specific worker node in a node pool
        /// </summary>
        public List<KubernetesNode> Nodes { get; set; }
    }
}
