using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class AppsStringMatch {
        /// <summary>
        /// [ 1 .. 256 ] characters
        /// Exact string match. Only 1 of exact, prefix, or regex must be set.
        /// </summary>
        [JsonProperty("exact")]
        public string Exact { get; set; }

        /// <summary>
        /// [ 1 .. 256 ] characters
        /// Prefix-based match. Only 1 of exact, prefix, or regex must be set.
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        /// <summary>
        /// [ 1 .. 256 ] characters
        /// RE2 style regex-based match. Only 1 of exact, prefix, or regex must be set. For more information about RE2 syntax, see: https://github.com/google/re2/wiki/Syntax
        /// </summary>
        [JsonProperty("regexp")]
        public string Regex { get; set; }
    }
}
