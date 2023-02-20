namespace DigitalOcean.Clients.Models.Requests; 

public class Project {
    /// <summary>
    /// The human-readable name for the project. The maximum length is 175 characters and the name must be unique.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The description of the project. The maximum length is 255 characters.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// The purpose of the project. The maximum length is 255 characters. For examples of valid purposes, see <see cref="Purposes"/>
    /// </summary>
    [JsonPropertyName("purpose")]
    public string Purpose { get; set; }

    /// <summary>
    /// The environment of the project's resources. List of valid environments, see <see cref="Enviroments"/>
    /// </summary>
    [JsonPropertyName("environment")]
    public string Environment { get; set; }

    /// <summary>
    /// The purpose attribute can have one of the following values.
    /// If specify another value for purpose, for example "your custom purpose",
    /// your purpose will be stored as Other: your custom purpose
    /// </summary>
    public static class Purposes {
        public const string TRYING = "Just trying out DigitalOcean";
        public const string EDUCATIONAL = "Class project / Educational purposes";
        public const string WEBSITE = "Website or blog";
        public const string WEB_APP = "Web Application";
        public const string SERVICE_OR_API = "Service or API";
        public const string MOBILE = "Mobile Application";
        public const string DATA_PROCESSING = "Machine learning / AI / Data processing";
        public const string IO_T = "IoT";
        public const string OPERATIONAL = "Operational / Developer tooling";
    }

    /// <summary>
    /// The environment attribute must have one of the following values.
    /// If another value is specified, a 400 Bad Request is returned.
    /// </summary>
    public static class Enviroments {
        public const string DEVELOPMENT = "Development";
        public const string STAGING = "Staging";
        public const string PRODUCTION = "Production";
    }
}