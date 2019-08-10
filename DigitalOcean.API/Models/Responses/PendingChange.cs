namespace DigitalOcean.API.Models.Responses {
    public class PendingChange {
        /// <summary>
        /// The id of the Droplet that will be updated.
        /// </summary>
        public int DropletId { get; set; }

        /// <summary>
        /// Whether this Firewall is being removed or not.
        /// </summary>
        public bool Removing { get; set; }

        /// <summary>
        /// Status of the pending change.
        /// </summary>
        public string Status { get; set; }
    }
}
