namespace DigitalOcean.API.Models.Responses {
    public class MaintenancePolicy {
        /// <summary>
        /// The start time in UTC of the maintenance window policy in 24-hour clock format / HH:MM notation (e.g., 15:00).
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// The duration of the maintenance window policy in human-readable format.
        /// </summary>
        public string Duration { get; set; }

        /// <summary>
        /// The day of the maintenance window policy. May be one of "monday" through "sunday", or "any" to indicate an arbitrary week day.
        /// </summary>
        public string Day { get; set; }
    }
}
