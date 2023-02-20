namespace DigitalOcean.Clients.Models.Requests; 

public enum KubernetesNodeDeleteType {
    Drain,
    SkipDrain,
    Replace
}