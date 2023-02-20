namespace DigitalOcean.Clients.Models.Requests; 

public class PatchProject {
    /// <summary>
    /// The human-readable name for the project. The maximum length is 175 characters.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The description of the project. The maximum length is 255 characters.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// The purpose of the project. The maximum length is 255 characters. For examples of valid purposes, see <see cref="Project.Purposes"/>
    /// </summary>
    [JsonPropertyName("purpose")]
    public string Purpose { get; set; }

    /// <summary>
    /// The environment of the project's resources. List of valid environments, see <see cref="Project.Enviroments"/>
    /// </summary>
    [JsonPropertyName("environment")]
    public string Environment { get; set; }

    /// <summary>
    /// If true, all resources will be added to this project if no project is specified.
    /// </summary>
    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; set; }
}