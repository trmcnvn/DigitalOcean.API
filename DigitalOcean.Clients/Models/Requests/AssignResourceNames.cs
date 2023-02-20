namespace DigitalOcean.Clients.Models.Requests; 

public class AssignResourceNames {
    /// <summary>
    /// A list of uniform resource names (URNs) to be added to a project.
    /// </summary>
    [JsonPropertyName("resources")]
    public List<string> Resources { get; set; }
}