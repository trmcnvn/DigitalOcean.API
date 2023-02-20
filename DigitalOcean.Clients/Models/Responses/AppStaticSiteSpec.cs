using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses; 

public class AppStaticSiteSpec {
    public string Name { get; set; }
    public AppsGitSourceSpec Git { get; set; }
    public AppsGithubSourceSpec Github { get; set; }
    public AppsGitlabSourceSpec Gitlab { get; set; }
    public AppsImageSourceSpec Image { get; set; }
    public string DockerfilePath { get; set; }
    public string BuildCommand { get; set; }
    public string RunCommand { get; set; }
    public string SourceDir { get; set; }
    public IList<AppVariableDefinition> Envs { get; set; }
    public string EnvironmentSlug { get; set; }
    public string IndexDocument { get; set; }
    public string ErrorDocument { get; set; }
    public string CatchallDocument { get; set; }
    public string OutputDir { get; set; }
    public AppsCorsPolicy Cors { get; set; }
    public IList<Routes> Routes { get; set; }
}