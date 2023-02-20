namespace DigitalOcean.API.Models.Requests {
    public class AppServiceSpecHealthCheck {
        /// <summary>
        /// The number of failed health checks before considered unhealthy.
        /// </summary>
        [JsonPropertyName("failure_threshold")]
        public int FailureThreshold { get; set; }

        /// <summary>
        /// The route path used for the HTTP health check ping. If not set, the HTTP health check will be disabled and a TCP health check used instead.
        /// </summary>
        [JsonPropertyName("http_path")]
        public string HttpPath { get; set; }

        /// <summary>
        /// The number of seconds to wait before beginning health checks.
        /// </summary>
        [JsonPropertyName("initial_delay_seconds")]
        public int InitialDelaySeconds { get; set; }

        /// <summary>
        /// The number of seconds to wait between health checks.
        /// </summary>
        [JsonPropertyName("period_seconds")]
        public int PeriodSeconds { get; set; }

        /// <summary>
        /// The number of successful health checks before considered healthy.
        /// </summary>
        [JsonPropertyName("success_threshold")]
        public int SuccessThreshold { get; set; }

        /// <summary>
        /// The number of seconds after which the check times out.
        /// </summary>
        [JsonPropertyName("timeout_seconds")]
        public int TimeoutSeconds { get; set; }
    }
}
