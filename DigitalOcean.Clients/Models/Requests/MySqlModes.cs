namespace DigitalOcean.Clients.Models.Requests; 

public class MySqlModes {
    /// <summary>
    /// A single string specifying the desired SQL modes for the MySQL cluster separated by commas.
    /// </summary>
    [JsonPropertyName("sql_mode")]
    public string SqlMode { get; set; }
}