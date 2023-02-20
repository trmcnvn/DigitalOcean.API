namespace DigitalOcean.API.Models.Responses; 

public class AppDatabaseSpec {
    public string ClusterName { get; set; }
    public string DbName { get; set; }
    public string DbUser { get; set; }
    public string DatabaseEngine { get; set; }
    public string Name { get; set; }
    public bool Production { get; set; }
    public string Version { get; set; }
}