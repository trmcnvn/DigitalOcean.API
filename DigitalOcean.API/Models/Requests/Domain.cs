using Newtonsoft.Json;

namespace DigitalOcean.API.Models.Requests {
    public class Domain {
        /// <summary>
        /// The domain name to add to the DigitalOcean DNS management interface. The name must be unique in DigitalOcean's DNS
        /// system. The request will fail if the name has already been taken.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// This attribute contains the IP address you want the domain to point to.
        /// </summary>
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }
    }
}