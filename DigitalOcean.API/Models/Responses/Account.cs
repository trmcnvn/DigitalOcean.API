namespace DigitalOcean.API.Models.Responses {
    public class Account {
        /// <summary>
        /// The total number of Droplets current user or team may have active at one time.
        /// </summary>
        public int DropletLimit { get; set; }

        /// <summary>
        ///	The total number of Floating IPs the current user or team may have.
        /// </summary>
        public int FloatingIpLimit { get; set; }

        /// <summary>
        /// The email address used by the current user to registered for DigitalOcean.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The unique universal identifier for the current user.
        /// </summary>
        public string UUID { get; set; }

        /// <summary>
        /// If true, the user has verified their account via email. False otherwise.
        /// </summary>
        public bool EmailVerified { get; set; }

        /// <summary>
        /// This value is one of "active", "warning" or "locked".
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// A human-readable message giving more details about the status of the account.
        /// </summary>
        public string StatusMessage { get; set; }
    }
}
