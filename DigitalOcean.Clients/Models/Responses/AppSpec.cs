using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses; 

public class AppSpec {
    public string Name { get; set; }
    public string Region { get; set; }
    public IList<AppDomainSpec> Domains { get; set; }
    public IList<AppServiceSpec> Services { get; set; }
    public IList<AppStaticSiteSpec> StaticSites { get; set; }
    public IList<AppJobSpec> Jobs { get; set; }
    public IList<AppWorkerSpec> Workers { get; set; }
    public IList<AppDatabaseSpec> Databases { get; set; }
}