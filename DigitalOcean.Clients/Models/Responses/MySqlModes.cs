namespace DigitalOcean.API.Models.Responses;

public class MySqlModes {
    /// <summary>
    /// A string specifying the configured SQL modes for the MySQL cluster.
    /// </summary>
    [JsonPropertyName("sql_mode")]
    public string SqlMode { get; set; }
}
