using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    /// <summary>
    /// The desired configuration of an application.
    /// </summary>
    public class AppSpec {
        /// <summary>
        /// [ 2 .. 32 ] characters ^[a-z][a-z0-9-]{0,30}[a-z0-9]$
        /// The name of the app. Must be unique across all apps in the same account.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Enum: "ams" "nyc" "fra"
        /// The slug form of the geographical origin of the app. Default: nearest available
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// A set of hostnames where the application will be available.
        /// </summary>
        [JsonProperty("domains")]
        public IList<AppDomainSpec> Domains { get; set; }

        /// <summary>
        /// Workloads which expose publicy-accessible HTTP services.
        /// </summary>
        [JsonProperty("services")]
        public IList<AppServiceSpec> Services { get; set; }

        /// <summary>
        /// Content which can be rendered to static web assets.
        /// </summary>
        [JsonProperty("static_sites")]
        public IList<AppStaticSiteSpec> StaticSites { get; set; }

        /// <summary>
        /// Pre and post deployment workloads which do not expose publicly-accessible HTTP routes.
        /// </summary>
        [JsonProperty("jobs")]
        public IList<AppJobSpec> Jobs { get; set; }

        /// <summary>
        /// Workloads which do not expose publicly-accessible HTTP services.
        /// </summary>
        /// <returns></returns>
        [JsonProperty("workers")]
        public IList<AppWorkerSpec> Workers { get; set; }

        /// <summary>
        /// Database instances which can provide persistence to workloads within the application.
        /// </summary>
        [JsonProperty("databases")]
        public IList<AppDatabaseSpec> Databases { get; set; }
    }
}
