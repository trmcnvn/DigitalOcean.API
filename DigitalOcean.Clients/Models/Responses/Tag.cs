namespace DigitalOcean.API.Models.Responses; 

public class Tag {
    /// <summary>
    /// The name of the tag. The supported characters for names include alphanumeric characters, dashes, and underscores.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// An embedded object containing key value pairs of resource type and resource statistics.
    /// </summary>
    public TagResourcesStatistics Resources { get; set; }
}