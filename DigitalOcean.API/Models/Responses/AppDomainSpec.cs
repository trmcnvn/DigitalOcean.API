namespace DigitalOcean.API.Models.Responses {
    public class AppDomainSpec {
        public string Domain { get; set; }
        public string Type { get; set; }
        public bool Wildcard { get; set; }
        public string Zone { get; set; }
    }
}
