using System.Collections.Generic;

namespace DigitalOcean.API.Models.Requests {
    public class AppJobSpec {
        /// <summary>
        /// [ 2 .. 32 ] characters ^[a-z][a-z0-9-]{0,30}[a-z0-9]$
        /// The name. Must be unique across all components within the same app.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("git")] public AppsGitSourceSpec Git { get; set; }
        [JsonPropertyName("github")] public AppsGithubSourceSpec GitHub { get; set; }
        [JsonPropertyName("gitlab")] public AppsGitlabSourceSpec GitLab { get; set; }
        [JsonPropertyName("image")] public AppsImageSourceSpec Image { get; set; }

        /// <summary>
        /// The path to the Dockerfile relative to the root of the repo. If set, it will be used to build this component. Otherwise, App Platform will attempt to build it using buildpacks.
        /// </summary>
        [JsonPropertyName("dockerfile_path")]
        public string DockerfilePath { get; set; }

        /// <summary>
        /// An optional build command to run while building this component from source.
        /// </summary>
        [JsonPropertyName("build_command")]
        public string BuildCommand { get; set; }

        /// <summary>
        /// An optional run command to override the component's default.
        /// </summary>
        [JsonPropertyName("run_command")]
        public string RunCommand { get; set; }

        /// <summary>
        /// An optional path to the working directory to use for the build. For Dockerfile builds, this will be used as the build context. Must be relative to the root of the repo.
        /// </summary>
        [JsonPropertyName("source_dir")]
        public string SourceDir { get; set; }

        /// <summary>
        /// A list of environment variables made available to the component.
        /// </summary>
        [JsonPropertyName("envs")]
        public IList<AppVariableDefinition> Envs { get; set; }

        /// <summary>
        /// An environment slug describing the type of this app.
        /// </summary>
        [JsonPropertyName("environment_slug")]
        public string EnvironmentSlug { get; set; }

        /// <summary>
        /// The amount of instances that this component should be scaled to.
        /// </summary>
        [JsonPropertyName("instance_count")]
        public int InstanceCount { get; set; }

        /// <summary>
        /// Enum: "basic-xxs" "basic-xs" "basic-s" "basic-m" "professional-xs" "professional-s" "professional-m" "professional-1l" "professional-l" "professional-xl"
        /// The instance size to use for this component.
        /// </summary>
        [JsonPropertyName("instance_size_slug")]
        public string InstanceSizeSlug { get; set; }

        /// <summary>
        /// Enum: "UNSPECIFIED" "PRE_DEPLOY" "POST_DEPLOY" "FAILED_DEPLOY"
        /// UNSPECIFIED: Default job type, will auto-complete to POST_DEPLOY kind.
        /// PRE_DEPLOY: Indicates a job that runs before an app deployment.
        /// POST_DEPLOY: Indicates a job that runs after an app deployment.
        /// FAILED_DEPLOY: Indicates a job that runs after a component fails to deploy.
        /// </summary>
        [JsonPropertyName("kind")]
        public string Kind { get; set; }
    }
}
