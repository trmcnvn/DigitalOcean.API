using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class AppsGithubSourceSpec {
        /// <summary>
        /// The name of the branch to use
        /// </summary>
        [JsonProperty("branch")]
        public string Branch { get; set; }

        /// <summary>
        /// Whether to automatically deploy new commits made to the repo
        /// </summary>
        [JsonProperty("deploy_on_push")]
        public bool DeployOnPush { get; set; }

        /// <summary>
        /// The name of the repo in the format owner/repo. Example: digitalocean/sample-golang
        /// </summary>
        [JsonProperty("repo")]
        public string Repo { get; set; }
    }
}
