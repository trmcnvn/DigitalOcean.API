namespace DigitalOcean.Clients.Models.Responses; 

public class Volume {
    /// <summary>
    /// The unique identifier for the Block Storage volume.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// The region where the Block Storage volume will be created. When setting a region, the value should be the slug identifier for the region. When you query a Block Storage volume, the entire region object will be returned.
    /// </summary>
    public Region Region { get; set; }

    /// <summary>
    /// An array containing the IDs of the Droplets the volume is attached to. Note that at this time, a volume can only be attached to a single Droplet.
    /// </summary>
    public List<long> DropletIds { get; set; }

    /// <summary>
    /// A human-readable name for the Block Storage volume. Must be lowercase and be composed only of numbers, letters and "-", up to a limit of 64 characters.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// An optional free-form text field to describe a Block Storage volume.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The size of the Block Storage volume in GiB (1024^3).
    /// </summary>
    public int SizeGigabytes { get; set; }

    /// <summary>
    /// A time value given in ISO8601 combined date and time format that represents when the Block Storage volume was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The type of filesystem currently in-use on the volume.
    /// </summary>
    public string FilesystemType { get; set; }

    /// <summary>
    /// The label currently applied to the filesystem.
    /// </summary>
    public string FilesystemLabel { get; set; }

    /// <summary>
    /// An array of Tags the volume has been tagged with
    /// </summary>
    public List<string> Tags { get; set; }
}