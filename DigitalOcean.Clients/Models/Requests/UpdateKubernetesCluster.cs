using System.Collections.Generic;

namespace DigitalOcean.API.Models.Requests {
    public class UpdateKubernetesCluster {
        /// <summary>
        /// A human-readable name for a Kubernetes cluster.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// A boolean value indicating whether the cluster will be automatically upgraded to new patch releases during its maintenance window.
        /// </summary>
        [JsonPropertyName("auto_upgrade")]
        public bool? AutoUpgrade { get; set; }

        /// <summary>
        /// A flat array of tag names as strings to be applied to the Kubernetes cluster. If excluded, existing user provided tags will be removed from the cluster.
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// An object specifying the maintenance window policy for the Kubernetes cluster.
        /// </summary>
        [JsonPropertyName("maintenance_policy")]
        public MaintenancePolicy MaintenancePolicy { get; set; }
    }
}
