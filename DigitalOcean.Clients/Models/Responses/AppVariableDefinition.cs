namespace DigitalOcean.Clients.Models.Responses; 

public class AppVariableDefinition {
    public string Key { get; set; }
    public string Scope { get; set; }
    public string Type { get; set; }
    public string Value { get; set; }
}