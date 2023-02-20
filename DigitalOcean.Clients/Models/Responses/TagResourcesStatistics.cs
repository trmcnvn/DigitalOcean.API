namespace DigitalOcean.Clients.Models.Responses; 

public class TagResourcesStatistics : TagResourceStatistics {
    public TagResourceStatistics Droplets { get; set; }

    public TagResourceStatistics Images { get; set; }

    public TagResourceStatistics Volumes { get; set; }

    public TagResourceStatistics VolumeSnapshots { get; set; }

    public TagResourceStatistics Databases { get; set; }
}

public class TagResourceStatistics {
    /// <summary>
    /// The number tagged objects for this type of resource.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// The URI for the last tagged object for this type of resource.
    /// </summary>
    public string LastTaggedUri { get; set; }
}