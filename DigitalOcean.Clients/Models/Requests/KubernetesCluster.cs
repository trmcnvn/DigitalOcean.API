using System.Collections.Generic;

namespace DigitalOcean.API.Models.Requests {
    public class KubernetesCluster {
        /// <summary>
        /// A human-readable name for a Kubernetes cluster.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The slug identifier for the region where the Kubernetes cluster will be created.
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// The slug identifier for the version of Kubernetes used for the cluster. See the /v2/kubernetes/options endpoint for available versions.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary>
        /// A boolean value indicating whether the cluster will be automatically upgraded to new patch releases during its maintenance window.
        /// </summary>
        [JsonPropertyName("auto_upgrade")]
        public bool? AutoUpgrade { get; set; }

        /// <summary>
        /// A flat array of tag names as strings to be applied to the Kubernetes cluster.
        /// All clusters will be automatically tagged "k8s" and "k8s:$K8S_CLUSTER_ID" in addition to any tags provided by the user.
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// An object specifying the maintenance window policy for the Kubernetes cluster.
        /// </summary>
        [JsonPropertyName("maintenance_policy")]
        public MaintenancePolicy MaintenancePolicy { get; set; }

        /// <summary>
        /// An object specifying the details of the worker nodes available to the Kubernetes cluster
        /// </summary>
        [JsonPropertyName("node_pools")]
        public List<KubernetesNodePool> NodePools { get; set; }

        /// <summary>
        /// A string specifying the UUID of the VPC to which the Kubernetes cluster will be assigned.
        /// If excluded, the cluster will be assigned to your account's default VPC for the region.
        /// </summary>
        [JsonPropertyName("vpc_uuid")]
        public string VpcUuid { get; set; }
    }
}
