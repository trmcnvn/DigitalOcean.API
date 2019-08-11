using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Responses {
    public class SourceLocation {
        /// <summary>
        /// An array of strings containing the IPv4 addresses, IPv6 addresses, IPv4 CIDRs, and/or IPv6 CIDRs to which the Firewall will allow traffic.
        /// </summary>
        public List<string> Addressess { get; set; }

        /// <summary>
        /// An array containing the IDs of the Droplets to which the Firewall will allow traffic.
        /// </summary>
        public List<int> DropletIds { get; set; }

        /// <summary>
        /// An array containing the IDs of the Load Balancers to which the Firewall will allow traffic.
        /// </summary>
        public List<string> LoadBalancerUids { get; set; }

        /// <summary>
        /// An array containing the names of Tags corresponding to groups of Droplets to which the Firewall will allow traffic.
        /// </summary>
        public List<string> Tags { get; set; }
    }
}
