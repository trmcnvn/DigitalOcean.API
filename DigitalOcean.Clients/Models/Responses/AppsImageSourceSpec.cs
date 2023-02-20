namespace DigitalOcean.Clients.Models.Responses; 

public class AppsImageSourceSpec {
    public string Registry { get; set; }
    public string RegistryType { get; set; }
    public string Repository { get; set; }
    public string Tag { get; set; }
}