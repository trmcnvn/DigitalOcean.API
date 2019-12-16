using System.Collections.Generic;

namespace DigitalOcean.API.Models.Responses {
    public class OutboundRule {
        /// <summary>
        /// The type of traffic to be allowed. This may be one of "tcp", "udp", or "icmp".
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// The ports on which traffic will be allowed specified as a string containing a single port, a range (e.g. "8000-9000"), or "all" to open all ports for a protocol. This parameter should be omited for ICMP rules.
        /// </summary>
        public string Ports { get; set; }

        /// <summary>
        /// An object specifying locations to which outbound traffic that will be allowed. (See below for the available keys and the types.)
        /// </summary>
        public SourceLocation Destinations { get; set; }
    }
}
