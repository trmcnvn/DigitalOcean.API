using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class UpdateProject {
        /// <summary>
        /// The human-readable name for the project. The maximum length is 175 characters.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The description of the project. The maximum length is 255 characters.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The purpose of the project. The maximum length is 255 characters. For examples of valid purposes, see <see cref="Project.Purposes"/>
        /// </summary>
        [JsonProperty("purpose")]
        public string Purpose { get; set; }

        /// <summary>
        /// The environment of the project's resources. List of valid environments, see <see cref="Project.Enviroments"/>
        /// </summary>
        [JsonProperty("environment")]
        public string Environment { get; set; }

        /// <summary>
        /// If true, all resources will be added to this project if no project is specified.
        /// </summary>
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }
    }
}
