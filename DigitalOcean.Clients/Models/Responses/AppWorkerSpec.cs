namespace DigitalOcean.Clients.Models.Responses; 

public class AppWorkerSpec {
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
    public int InstanceCount { get; set; }
    public string InstanceSizeSlug { get; set; }
}