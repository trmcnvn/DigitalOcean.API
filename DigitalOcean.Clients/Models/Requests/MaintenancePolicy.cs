namespace DigitalOcean.Clients.Models.Requests; 

public class MaintenancePolicy {
    /// <summary>
    /// The start time in UTC of the maintenance window policy in 24-hour clock format / HH:MM notation (e.g., 15:00).
    /// </summary>
    [JsonPropertyName("start_time")]
    public string StartTime { get; set; }

    /// <summary>
    /// The day of the maintenance window policy. May be one of "monday" through "sunday", or "any" to indicate an arbitrary week day.
    /// </summary>
    [JsonPropertyName("day")]
    public string Day { get; set; }
}