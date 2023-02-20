using System;
using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses; 

/// <summary>
/// Snapshots are saved instances of a Droplet or a block storage volume, which is reflected in the resource_type attribute.
/// In order to avoid problems with compressing filesystems, each defines a min_disk_size attribute which is the minimum size of the
/// Droplet or volume disk when creating a new resource from the saved snapshot.
/// </summary>
public class Snapshot {
    /// <summary>
    /// The unique identifier for the snapshot.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// A human-readable name for the snapshot.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A time value given in ISO8601 combined date and time format that represents when the snapshot was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// An array of the regions that the image is available in. The regions are represented by their identifying slug values.
    /// </summary>
    public List<string> Regions { get; set; }

    /// <summary>
    /// A unique identifier for the resource that the action is associated with.
    /// </summary>
    public string ResourceId { get; set; }

    /// <summary>
    /// The type of resource that the action is associated with.
    /// </summary>
    public string ResourceType { get; set; }

    /// <summary>
    /// The minimum size in GB required for a volume or Droplet to use this snapshot.
    /// </summary>
    public int MinDiskSize { get; set; }

    /// <summary>
    /// The billable size of the snapshot in gigabytes.
    /// </summary>
    public double SizeGigabytes { get; set; }

    /// <summary>
    /// An array of Tags the snapshot has been tagged with
    /// </summary>
    public List<string> Tags { get; set; }
}