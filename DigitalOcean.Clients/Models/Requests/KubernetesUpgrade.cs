namespace DigitalOcean.API.Models.Requests {
    public class KubernetesUpgrade {
        /// <summary>
        /// The slug identifier for the version of Kubernetes to upgrade to.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
