namespace DigitalOcean.API.Models.Requests {
    public class Specs {
        [JsonPropertyName("spec")]
        public AppSpec Spec { get; set; }
    }
}
