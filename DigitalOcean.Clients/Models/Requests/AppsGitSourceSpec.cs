namespace DigitalOcean.API.Models.Requests {
    public class AppsGitSourceSpec {
        /// <summary>
        /// The name of the branch to use
        /// </summary>
        [JsonPropertyName("branch")]
        public string Branch { get; set; }

        /// <summary>
        /// The clone URL of the repo. Example: https://github.com/digitalocean/sample-golang.git
        /// </summary>
        [JsonPropertyName("repo_clone_url")]
        public string RepoCloneUrl { get; set; }
    }
}
