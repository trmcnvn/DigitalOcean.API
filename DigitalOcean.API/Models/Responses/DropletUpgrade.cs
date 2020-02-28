using System;

namespace DigitalOcean.API.Models.Responses {
    public class DropletUpgrade {
        /// <summary>
        /// The affected droplet's ID
        /// </summary>
        public long DropletId { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the migration will occur for the droplet.
        /// </summary>
        public string DateOfMigration { get; set; }

        /// <summary>
        /// A URL pointing to the Droplet's API endpoint. This is the endpoint to be used if you want to retrieve information about the droplet.
        /// </summary>
        public string Url { get; set; }
    }
}

