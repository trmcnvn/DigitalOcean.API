using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Responses {
    public class DeploymentSteps {
        public string ComponentName { get; set; }
        public DateTime EndedAt { get; set; }
        public string MessageBase { get; set; }
        public string Name { get; set; }
        public AppsDeploymentProgressStepReason Reason { get; set; }
        public DateTime StartedAt { get; set; }
        public AppsDeploymentProgressStepStatus Status { get; set; }
        [JsonProperty("steps")]
        public IList<DeploymentSteps> ChildSteps { get; set; }
    }
}
