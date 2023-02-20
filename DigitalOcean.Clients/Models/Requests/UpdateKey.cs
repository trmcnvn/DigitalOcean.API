namespace DigitalOcean.Clients.Models.Requests; 

public class UpdateKey {
    /// <summary>
    /// The name to give the new SSH key in your account.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }
}