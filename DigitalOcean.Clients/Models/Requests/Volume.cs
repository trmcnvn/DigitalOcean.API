namespace DigitalOcean.Clients.Models.Requests; 

public class Volume {
    /// <summary>
    /// The size of the Block Storage volume in GiB (1024^3).
    /// </summary>
    [JsonPropertyName("size_gigabytes")]
    public int SizeGigabytes { get; set; }

    /// <summary>
    /// A human-readable name for the Block Storage volume. Must be lowercase and be composed only of numbers, letters and "-", up to a limit of 64 characters.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// An optional free-form text field to describe a Block Storage volume.
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// The region where the Block Storage volume will be created. When setting a region, the value should be the slug identifier for the region. When you query a Block Storage volume, the entire region object will be returned.
    /// </summary>
    [JsonPropertyName("region")]
    public string Region { get; set; }

    /// <summary>
    /// The unique identifier for the volume snapshot from which to create the volume. Should not be specified with a region_id.
    /// </summary>
    [JsonPropertyName("snapshot_id")]
    public string SnapshotId { get; set; }

    /// <summary>
    /// The name of the filesystem type to be used on the volume. When provided, the volume will automatically be formatted to the specified filesystem type. Currently, the available options are "ext4" and "xfs".
    /// </summary>
    [JsonPropertyName("filesystem_type")]
    public string FilesystemType { get; set; }

    /// <summary>
    /// The label to be applied to the filesystem. Labels for ext4 type filesystems may contain 16 characters while lables for xfs type filesystems are limited to 12 characters. May only be used in conjunction with filesystem_type.
    /// </summary>
    [JsonPropertyName("filesystem_label")]
    public string FilesystemLabel { get; set; }

    /// <summary>
    /// A flat array of tag names as strings to apply to the Volume after it is created. Tag names can either be existing or new tags.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string> Tags { get; set; }
}