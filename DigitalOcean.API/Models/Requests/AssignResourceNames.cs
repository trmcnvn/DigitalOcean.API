using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class AssignResourceNames {
        /// <summary>
        /// A list of uniform resource names (URNs) to be added to a project.
        /// </summary>
        [JsonProperty("resources")]
        public List<string> Resources { get; set; }
    }
}
