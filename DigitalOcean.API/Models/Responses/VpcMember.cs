using System;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Responses {
    public class VpcMember {
        /// <summary>
        /// The name of the resource.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The uniform resource name (URN) for the resource in the format do:resource_type:resource_id.
        /// </summary>
        [JsonProperty("urn")]
        public string Urn { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the resource was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
