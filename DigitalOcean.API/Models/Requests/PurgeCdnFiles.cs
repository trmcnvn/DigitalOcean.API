using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class PurgeCdnFiles {
        /// <summary>
        /// An array of strings containing the path to the content to be purged from the CDN cache.
        /// </summary>
        [JsonProperty("files")]
        public List<string> Files { get; set; }
    }
}
