using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class AppJobSpec {
        /// <summary>
        /// [ 2 .. 32 ] characters ^[a-z][a-z0-9-]{0,30}[a-z0-9]$
        /// The name. Must be unique across all components within the same app.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("git")] public AppsGitSourceSpec Git { get; set; }
        [JsonProperty("github")] public AppsGithubSourceSpec GitHub { get; set; }
        [JsonProperty("gitlab")] public AppsGitlabSourceSpec GitLab { get; set; }
        [JsonProperty("image")] public AppsImageSourceSpec Image { get; set; }

        /// <summary>
        /// The path to the Dockerfile relative to the root of the repo. If set, it will be used to build this component. Otherwise, App Platform will attempt to build it using buildpacks.
        /// </summary>
        [JsonProperty("dockerfile_path")]
        public string DockerfilePath { get; set; }

        /// <summary>
        /// An optional build command to run while building this component from source.
        /// </summary>
        [JsonProperty("build_command")]
        public string BuildCommand { get; set; }

        /// <summary>
        /// An optional run command to override the component's default.
        /// </summary>
        [JsonProperty("run_command")]
        public string RunCommand { get; set; }

        /// <summary>
        /// An optional path to the working directory to use for the build. For Dockerfile builds, this will be used as the build context. Must be relative to the root of the repo.
        /// </summary>
        [JsonProperty("source_dir")]
        public string SourceDir { get; set; }

        /// <summary>
        /// A list of environment variables made available to the component.
        /// </summary>
        [JsonProperty("envs")]
        public IList<AppVariableDefinition> Envs { get; set; }

        /// <summary>
        /// An environment slug describing the type of this app.
        /// </summary>
        [JsonProperty("environment_slug")]
        public string EnvironmentSlug { get; set; }

        /// <summary>
        /// The amount of instances that this component should be scaled to.
        /// </summary>
        [JsonProperty("instance_count")]
        public int InstanceCount { get; set; }

        /// <summary>
        /// Enum: "basic-xxs" "basic-xs" "basic-s" "basic-m" "professional-xs" "professional-s" "professional-m" "professional-1l" "professional-l" "professional-xl"
        /// The instance size to use for this component.
        /// </summary>
        [JsonProperty("instance_size_slug")]
        public string InstanceSizeSlug { get; set; }

        /// <summary>
        /// Enum: "UNSPECIFIED" "PRE_DEPLOY" "POST_DEPLOY" "FAILED_DEPLOY"
        /// UNSPECIFIED: Default job type, will auto-complete to POST_DEPLOY kind.
        /// PRE_DEPLOY: Indicates a job that runs before an app deployment.
        /// POST_DEPLOY: Indicates a job that runs after an app deployment.
        /// FAILED_DEPLOY: Indicates a job that runs after a component fails to deploy.
        /// </summary>
        [JsonProperty("kind")]
        public string Kind { get; set; }
    }
}
