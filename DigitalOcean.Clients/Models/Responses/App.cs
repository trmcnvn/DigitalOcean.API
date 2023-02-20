namespace DigitalOcean.Clients.Models.Responses;

public class App {
    public Deployment ActiveDeployment { get; set; }
    public DateTime CreatedAt { get; set; }
    public string DefaultIngress { get; set; }
    public IList<AppDomains> Domains { get; set; }
    public string Id { get; set; }
    public Deployment InProgressDeployment { get; set; }
    public DateTime LastDeploymentCreatedAt { get; set; }
    public string LiveDomain { get; set; }
    public string LiveUrl { get; set; }
    public string LiveUrlBase { get; set; }
    public string OwnerUuid { get; set; }
    public AppRegion Region { get; set; }
    public AppSpec Spec { get; set; }
    public string TierSlug { get; set; }
    public DateTime UpdatedAt { get; set; }
}
