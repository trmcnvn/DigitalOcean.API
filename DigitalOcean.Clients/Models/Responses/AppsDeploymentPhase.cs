namespace DigitalOcean.Clients.Models.Responses; 

public enum AppsDeploymentPhase {
    Unknown,
    PendingBuild,
    Building,
    PendingDeploy,
    Deploying,
    Active,
    Superseded,
    Error,
    Canceled
}