using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses; 

public class AppDomainProgress {
    public IList<string> Steps { get; set; }
}