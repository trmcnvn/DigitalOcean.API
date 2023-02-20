namespace DigitalOcean.Clients.Models.Responses;

public class AppDomains {
    public string Id { get; set; }
    public AppsDomainPhase Phase { get; set; }
    public AppDomainProgress Progress { get; set; }
    public AppDomainSpec Spec { get; set; }
}
