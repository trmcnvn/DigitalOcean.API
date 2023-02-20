namespace DigitalOcean.Clients.Models.Requests; 

public class VolumeSnapshot {
    /// <summary>
    /// A human-readable name for the volume snapshot.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// A flat array of tag names as strings to apply to the volume snapshot after it is created. Tag names can either be existing or new tags.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }
}