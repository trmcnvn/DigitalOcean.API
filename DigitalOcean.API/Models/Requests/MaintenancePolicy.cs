using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class MaintenancePolicy {
        /// <summary>
        /// The start time in UTC of the maintenance window policy in 24-hour clock format / HH:MM notation (e.g., 15:00).
        /// </summary>
        [JsonProperty("start_time")]
        public string StartTime { get; set; }

        /// <summary>
        /// The day of the maintenance window policy. May be one of "monday" through "sunday", or "any" to indicate an arbitrary week day.
        /// </summary>
        [JsonProperty("day")]
        public string Day { get; set; }
    }
}
