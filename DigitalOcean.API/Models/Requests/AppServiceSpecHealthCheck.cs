using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class AppServiceSpecHealthCheck {
        /// <summary>
        /// The number of failed health checks before considered unhealthy.
        /// </summary>
        [JsonProperty("failure_threshold")]
        public int FailureThreshold { get; set; }

        /// <summary>
        /// The route path used for the HTTP health check ping. If not set, the HTTP health check will be disabled and a TCP health check used instead.
        /// </summary>
        [JsonProperty("http_path")]
        public string HttpPath { get; set; }

        /// <summary>
        /// The number of seconds to wait before beginning health checks.
        /// </summary>
        [JsonProperty("initial_delay_seconds")]
        public int InitialDelaySeconds { get; set; }

        /// <summary>
        /// The number of seconds to wait between health checks.
        /// </summary>
        [JsonProperty("period_seconds")]
        public int PeriodSeconds { get; set; }

        /// <summary>
        /// The number of successful health checks before considered healthy.
        /// </summary>
        [JsonProperty("success_threshold")]
        public int SuccessThreshold { get; set; }

        /// <summary>
        /// The number of seconds after which the check times out.
        /// </summary>
        [JsonProperty("timeout_seconds")]
        public int TimeoutSeconds { get; set; }
    }
}
