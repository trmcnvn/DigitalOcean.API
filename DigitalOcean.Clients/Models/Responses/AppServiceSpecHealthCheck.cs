namespace DigitalOcean.Clients.Models.Responses; 

public class AppServiceSpecHealthCheck {
    public int FailureThreshold { get; set; }
    public string HttpPath { get; set; }
    public int InitialDelaySeconds { get; set; }
    public int PeriodSeconds { get; set; }
    public int SuccessThreshold { get; set; }
    public int TimeoutSeconds { get; set; }
}