using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses; 

public class AppsDeploymentProgress {
    public int ErrorSteps { get; set; }
    public int PendingSteps { get; set; }
    public int RunningSteps { get; set; }
    public IList<DeploymentSteps> Steps { get; set; }
    public int SuccessSteps { get; set; }
    public IList<DeploymentSteps> SummarySteps { get; set; }
    public int TotalSteps { get; set; }

}