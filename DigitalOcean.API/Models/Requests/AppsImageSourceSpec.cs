using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class AppsImageSourceSpec {
        /// <summary>
        /// The registry name. Must be left empty for the DOCR registry type.
        /// </summary>
        [JsonProperty("registry")]
        public string Registry { get; set; }

        /// <summary>
        /// Enum: "DOCKER_HUB" "DOCR"
        /// DOCKER_HUB: The DockerHub container registry type.
        /// DOCR: The DigitalOcean container registry type.
        /// </summary>
        [JsonProperty("registry_type")]
        public string RegistryType { get; set; }

        /// <summary>
        /// The repository name.
        /// </summary>
        [JsonProperty("repository")]
        public string Repository { get; set; }

        /// <summary>
        /// The repository tag. Defaults to latest if not provided.
        /// </summary>
        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}
