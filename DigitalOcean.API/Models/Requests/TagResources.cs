using Newtonsoft.Json;
using System.Collections.Generic;

namespace DigitalOcean.API.Models.Requests {
    public class TagResources {
        /// <summary>
        /// The list of resources to be tagged
        /// </summary>
        [JsonProperty("resources")]
        public List<TagResource> Resources { get; set; }
    }
}
