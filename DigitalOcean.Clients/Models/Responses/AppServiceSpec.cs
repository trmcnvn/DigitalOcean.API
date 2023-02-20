namespace DigitalOcean.Clients.Models.Responses; 

public class AppServiceSpec {
    public string Name { get; set; }
    public AppsGitSourceSpec Git { get; set; }
    public AppsGithubSourceSpec GitHub { get; set; }
    public AppsGitlabSourceSpec GitLab { get; set; }
    public AppsImageSourceSpec Image { get; set; }
    public string DockerfilePath { get; set; }
    public string BuildCommand { get; set; }
    public string RunCommand { get; set; }
    public string SourceDir { get; set; }
    public IList<AppVariableDefinition> Envs { get; set; }
    public string EnvironmentSlug { get; set; }
    public int InstanceCount { get; set; }
    public string InstanceSizeSlug { get; set; }
    public AppsCorsPolicy Cors { get; set; }
    public AppServiceSpecHealthCheck HealthCheck { get; set; }
    public int HttpPort { get; set; }
    public IList<int> InternalPorts { get; set; }
    public IList<Routes> Routes { get; set; }
}