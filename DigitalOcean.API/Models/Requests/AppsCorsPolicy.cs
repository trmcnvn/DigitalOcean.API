using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class AppsCorsPolicy {
        /// <summary>
        /// The set of allowed CORS origins.
        /// </summary>
        [JsonProperty("allow_origins")]
        public IList<AppsStringMatch> AllowOrigins { get; set; }

        /// <summary>
        /// The set of allowed HTTP methods. This configures the Access-Control-Allow-Methods header.
        /// </summary>
        [JsonProperty("allow_methods")]
        public IList<string> AllowMethods { get; set; }

        /// <summary>
        /// The set of allowed HTTP request headers. This configures the Access-Control-Allow-Headers header.
        /// </summary>
        [JsonProperty("allow_headers")]
        public IList<string> AllowHeaders { get; set; }

        /// <summary>
        /// The set of HTTP response headers that browsers are allowed to access. This configures the Access-Control-Expose-Headers header.
        /// </summary>
        [JsonProperty("expose_headers")]
        public IList<string> ExposeHeaders { get; set; }

        /// <summary>
        /// An optional duration specifying how long browsers can cache the results of a preflight request. This configures the Access-Control-Max-Age header.
        /// </summary>
        [JsonProperty("max_age")]
        public string MaxAge { get; set; }

        /// <summary>
        /// Whether browsers should expose the response to the client-side JavaScript code when the request’s credentials mode is include. This configures the Access-Control-Allow-Credentials header.
        /// </summary>
        [JsonProperty("allow_credentials")]
        public bool AllowCredentials { get; set; }
    }
}
