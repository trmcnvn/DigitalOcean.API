namespace DigitalOcean.Clients.Models.Responses; 

public class AppsCorsPolicy {
    public IList<AppsStringMatch> AllowOrigins { get; set; }
    public IList<string> AllowMethods { get; set; }
    public IList<string> AllowHeaders { get; set; }
    public IList<string> ExposeHeaders { get; set; }
    public string MaxAge { get; set; }
    public bool AllowCredentials { get; set; }
}