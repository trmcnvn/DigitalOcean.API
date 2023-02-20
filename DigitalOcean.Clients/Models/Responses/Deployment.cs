namespace DigitalOcean.Clients.Models.Responses; 

public class Deployment {
    public string Cause { get; set; }
    public string ClonedFrom { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Id { get; set; }
    public IList<DeploymentJobs> Jobs { get; set; }
    public AppsDeploymentPhase Phase { get; set; }
    public DateTime PhaseLastUpdatedAt { get; set; }
    public AppsDeploymentProgress Progress { get; set; }
    public IList<DeploymentServices> Services { get; set; }
    public AppSpec Spec { get; set; }
    public IList<DeploymentStaticSites> StaticSites { get; set; }
    public string TierSlug { get; set; }
    public DateTime UpdatedAt { get; set; }
    public IList<DeploymentWorkers> Workers { get; set; }
}