using Newtonsoft.Json;
using System.Collections.Generic;

namespace DigitalOcean.API.Models.Requests {
    public class TagResource {
        /// <summary>
        /// The list of resources to be tagged
        /// </summary>
        [JsonProperty("resources")]
        public List<Resource> Resources { get; set; }

        public class Resource {
            /// <summary>
            /// The id of the resource to be tagged
            /// </summary>
            [JsonProperty("resource_id")]
            public string Id;

            /// <summary>
            /// The type of the resource to be tagged
            /// </summary>
            [JsonProperty("resource_type")]
            public string Type;
        }
    }
}
