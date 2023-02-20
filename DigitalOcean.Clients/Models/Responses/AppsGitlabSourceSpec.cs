namespace DigitalOcean.API.Models.Responses; 

public class AppsGitlabSourceSpec {
    public string Branch { get; set; }
    public bool DeployOnPush { get; set; }
    public string Repo { get; set; }
}