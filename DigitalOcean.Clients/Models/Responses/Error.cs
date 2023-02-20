namespace DigitalOcean.Clients.Models.Responses;

public class Error {
    /// <summary>
    /// The error identifier
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// Detailed error message
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }
}
