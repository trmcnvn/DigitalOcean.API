using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class AppsGitSourceSpec {
        /// <summary>
        /// The name of the branch to use
        /// </summary>
        [JsonProperty("branch")]
        public string Branch { get; set; }

        /// <summary>
        /// The clone URL of the repo. Example: https://github.com/digitalocean/sample-golang.git
        /// </summary>
        [JsonProperty("repo_clone_url")]
        public string RepoCloneUrl { get; set; }
    }
}
