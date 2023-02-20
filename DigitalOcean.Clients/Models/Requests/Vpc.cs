namespace DigitalOcean.API.Models.Requests {
    public class Vpc {
        /// <summary>
        /// The name of the VPC.
        /// Must be unique and contain alphanumeric characters, dashes, and periods only.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// A free-form text field for describing the VPC's purpose.
        /// It may be a maximum of 255 characters.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The slug identifier for the region where the VPC will be created.
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// The requested range of IP addresses for the VPC in CIDR notation.
        /// Network ranges cannot overlap with other networks in the same account and must be in range of private
        /// addresses as defined in RFC1918. It may not be smaller than /24 nor larger than /16.
        /// </summary>
        [JsonPropertyName("ip_range")]
        public string IpRange { get; set; }
    }
}
