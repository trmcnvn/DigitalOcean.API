using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses; 

public class AppRegion {
    public string Continent { get; set; }
    public IList<string> DataCenters { get; set; }
    public bool Default { get; set; }
    public bool Disabled { get; set; }
    public string Flag { get; set; }
    public string Label { get; set; }
    public string Reason { get; set; }
    public string Slug { get; set; }
}