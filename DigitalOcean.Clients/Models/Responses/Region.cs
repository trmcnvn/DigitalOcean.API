using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses; 

public class Region {
    /// <summary>
    /// A human-readable string that is used as a unique identifier for each region.
    /// </summary>
    public string Slug { get; set; }

    /// <summary>
    /// The display name of the region. This will be a full name that is used in the control panel and other interfaces.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// This attribute is set to an array which contains the identifying slugs for the sizes available in this region.
    /// </summary>
    public List<string> Sizes { get; set; }

    /// <summary>
    /// This is a boolean value that represents whether new Droplets can be created in this region
    /// </summary>
    public bool Available { get; set; }

    /// <summary>
    /// This attribute is set to an array which contains features available in this region
    /// </summary>
    public List<string> Features { get; set; }
}