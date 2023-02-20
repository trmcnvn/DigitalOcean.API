namespace DigitalOcean.API.Models.Requests {
    public class UpdateDomainRecord {
        /// <summary>
        /// The record type (A, MX, CNAME, etc).
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The host name, alias, or service being defined by the record.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Variable data depending on record type.
        /// For example, the "data" value for an A record would be the IPv4 address to which the domain will be mapped.
        /// For a CAA record, it would contain the domain name of the CA being granted permission to issue certificates.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }

        /// <summary>
        /// The priority of the host (for SRV and MX records. null otherwise).
        /// </summary>
        [JsonPropertyName("priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// The port that the service is accessible on (for SRV records only. null otherwise).
        /// </summary>
        [JsonPropertyName("port")]
        public int? Port { get; set; }

        /// <summary>
        /// This value is the time to live for the record, in seconds. This defines the time frame that clients can cache queried information
        /// before a refresh should be requested. There is a minimum ttl value of 30, unless it is not set. If not set, the default value is
        /// the value of the SOA record. For SOA records, defines the time to live for purposes of negative caching.
        /// </summary>
        [JsonPropertyName("ttl")]
        public int? Ttl { get; set; }

        /// <summary>
        /// The weight of records with the same priority (for SRV records only. null otherwise).
        /// </summary>
        [JsonPropertyName("weight")]
        public int? Weight { get; set; }


        /// <summary>
        /// An unsigned integer between 0-255 used for CAA records.
        /// </summary>
        [JsonPropertyName("flags")]
        public int? Flags { get; set; }

        /// <summary>
        /// The parameter tag for CAA records. Valid values are "issue", "issuewild", or "iodef"
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag { get; set; }

    }
}
