using System.Collections.Generic;

namespace DigitalOcean.API.Models.Requests {
    public class PurgeCdnFiles {
        /// <summary>
        /// An array of strings containing the path to the content to be purged from the CDN cache.
        /// </summary>
        [JsonPropertyName("files")]
        public List<string> Files { get; set; }
    }
}
