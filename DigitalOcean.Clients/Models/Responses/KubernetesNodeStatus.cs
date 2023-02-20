namespace DigitalOcean.Clients.Models.Responses; 

public class KubernetesNodeStatus {
    /// <summary>
    /// Potential values include running, provisioning, and errored.
    /// </summary>
    public string State { get; set; }
}