namespace DigitalOcean.API.Models.Requests {
    public class ForceBuildApp {
        [JsonPropertyName("force_build")] public bool ForceBuild { get; set; }
    }
}
