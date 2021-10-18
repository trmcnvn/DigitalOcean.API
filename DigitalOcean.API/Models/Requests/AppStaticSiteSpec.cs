using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class AppStaticSiteSpec {
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
        /// The name of the index document to use when serving this static site.
        /// </summary>
        [JsonProperty("index_document")]
        public string IndexDocument { get; set; }
        /// <summary>
        /// The name of the error document to use when serving this static site.  If no such file exists within the built assets, App Platform will supply one.
        /// </summary>
        [JsonProperty("error_document")]
        public string ErrorDocument { get; set; }
        /// <summary>
        /// The name of the document to use as the fallback for any requests to documents that are not found when serving this static site. Only 1 of catchall_document or error_document can be set.
        /// </summary>
        [JsonProperty("catchall_document")]
        public string CatchallDocument { get; set; }
        /// <summary>
        /// An optional path to where the built assets will be located, relative to the build context. If not set, App Platform will automatically scan for these directory names: _static, dist, public, build
        /// </summary>
        [JsonProperty("output_dir")]
        public string OutputDir { get; set; }
        [JsonProperty("cors")]
        public AppsCorsPolicy Cors { get; set; }
        /// <summary>
        /// A list of HTTP routes that should be routed to this component.
        /// </summary>
        [JsonProperty("routes")]
        public IList<Routes> Routes { get; set; }
    }
}
