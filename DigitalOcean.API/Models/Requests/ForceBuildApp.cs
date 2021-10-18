using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class ForceBuildApp {
        [JsonProperty("force_build")] public bool ForceBuild { get; set; }
    }
}
