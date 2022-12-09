using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class Specs {
        [JsonProperty("spec")]
        public AppSpec Spec { get; set; }
    }
}
