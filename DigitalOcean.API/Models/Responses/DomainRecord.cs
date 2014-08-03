namespace DigitalOcean.API.Models.Responses {
    public class DomainRecord {
        /// <summary>
        /// The unique id for the individual record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The DNS record type (A, MX, CNAME, etc).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The host name, alias, or service being defined by the record.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Variable data depending on record type.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// The priority of the host (for SRV and MX records. null otherwise).
        /// </summary>
        public int? Priority { get; set; }

        /// <summary>
        /// The port that the service is accessible on (for SRV records only. null otherwise).
        /// </summary>
        public int? Port { get; set; }

        /// <summary>
        /// The weight of records with the same priority (for SRV records only. null otherwise).
        /// </summary>
        public int? Weight { get; set; }
    }
}