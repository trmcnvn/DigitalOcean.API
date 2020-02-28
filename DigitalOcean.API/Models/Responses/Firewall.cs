using System;
using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses {
    public class Firewall {
        /// <summary>
        /// A unique ID that can be used to identify and reference a Firewall.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A status string indicating the current state of the Firewall. This can be "waiting", "succeeded", or "failed".
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the Firewall was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// An array of objects each containing the fields "droplet_id", "removing", and "status". It is provided to detail exactly which Droplets are having their security policies updated. When empty, all changes have been successfully applied.
        /// </summary>
        public List<PendingChange> PendingChanges { get; set; }

        /// <summary>
        /// A human-readable name for a Firewall.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// An object specifying the inbound access rules for a Firewall.
        /// </summary>
        public List<InboundRule> InboundRules { get; set; }

        /// <summary>
        /// An object specifying the inbound access rules for a Firewall/
        /// </summary>
        public List<OutboundRule> OutboundRules { get; set; }

        /// <summary>
        /// An array containing the IDs of the Droplets assigned to the Firewall.
        /// </summary>
        public List<long> DropletIds { get; set; }

        /// <summary>
        /// An array containing the names of the Tags assigned to the Firewall.
        /// </summary>
        public List<string> Tags { get; set; }
    }
}
