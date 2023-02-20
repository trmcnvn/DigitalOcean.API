namespace DigitalOcean.Clients.Models.Requests; 

public class Specs {
    [JsonPropertyName("spec")]
    public AppSpec Spec { get; set; }
}