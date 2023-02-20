namespace DigitalOcean.Clients.Models.Requests; 

public class MaintenanceWindow {
    /// <summary>
    /// The day of the week on which to apply maintenance updates (e.g. "tuesday").
    /// </summary>
    [JsonPropertyName("day")]
    public string Day { get; set; }

    /// <summary>
    /// The hour in UTC at which maintenance updates will be applied in 24 hour format (e.g. "16:00")
    /// </summary>
    [JsonPropertyName("hour")]
    public string Hour { get; set; }
}