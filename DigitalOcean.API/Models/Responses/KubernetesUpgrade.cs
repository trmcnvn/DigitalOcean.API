namespace DigitalOcean.API.Models.Responses {
    public class KubernetesUpgrade {
        /// <summary>
        /// The slug identifier for this Kubernetes version
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// The version number of this Kubernetes version
        /// </summary>
        public string KubernetesVersion { get; set; }
    }
}
