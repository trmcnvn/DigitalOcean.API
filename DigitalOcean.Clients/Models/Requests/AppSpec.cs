using System.Collections.Generic;

namespace DigitalOcean.API.Models.Requests {
    /// <summary>
    /// The desired configuration of an application.
    /// </summary>
    public class AppSpec {
        /// <summary>
        /// [ 2 .. 32 ] characters ^[a-z][a-z0-9-]{0,30}[a-z0-9]$
        /// The name of the app. Must be unique across all apps in the same account.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Enum: "ams" "nyc" "fra"
        /// The slug form of the geographical origin of the app. Default: nearest available
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// A set of hostnames where the application will be available.
        /// </summary>
        [JsonPropertyName("domains")]
        public IList<AppDomainSpec> Domains { get; set; }

        /// <summary>
        /// Workloads which expose publicy-accessible HTTP services.
        /// </summary>
        [JsonPropertyName("services")]
        public IList<AppServiceSpec> Services { get; set; }

        /// <summary>
        /// Content which can be rendered to static web assets.
        /// </summary>
        [JsonPropertyName("static_sites")]
        public IList<AppStaticSiteSpec> StaticSites { get; set; }

        /// <summary>
        /// Pre and post deployment workloads which do not expose publicly-accessible HTTP routes.
        /// </summary>
        [JsonPropertyName("jobs")]
        public IList<AppJobSpec> Jobs { get; set; }

        /// <summary>
        /// Workloads which do not expose publicly-accessible HTTP services.
        /// </summary>
        /// <returns></returns>
        [JsonPropertyName("workers")]
        public IList<AppWorkerSpec> Workers { get; set; }

        /// <summary>
        /// Database instances which can provide persistence to workloads within the application.
        /// </summary>
        [JsonPropertyName("databases")]
        public IList<AppDatabaseSpec> Databases { get; set; }
    }
}
